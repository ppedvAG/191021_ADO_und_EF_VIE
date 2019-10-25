using Microsoft.EntityFrameworkCore;
using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;
using System;
using System.Linq;

namespace EFConcurrencyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFContext())
            {
                var aircraft = context.AircraftType.Single(p => p.ID == 1);
                aircraft.Manufacturer = "555-7777777-5555";

                // Change the person's name in the database to simulate a concurrency conflict
                context.Database.ExecuteSqlRaw(
                    "UPDATE dbo.AircraftType SET Manufacturer = 'das allerletzte mal - jetzt wirklich', ModifiedDate='0005-10-25 11:31:04.9440805' WHERE ID = 1");

                var saved = false;
                while (!saved)
                {
                    try
                    {
                        // Attempt to save changes to the database
                        if (context.ChangeTracker.HasChanges())
                        {
                            context.SaveChanges();
                        }
                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        foreach (var entry in ex.Entries)
                        {
                            if (entry.Entity is AircraftType)
                            {
                                var proposedValues = entry.CurrentValues;
                                var databaseValues = entry.GetDatabaseValues();

                                foreach (var property in proposedValues.Properties)
                                {
                                    var proposedValue = proposedValues[property];
                                    var databaseValue = databaseValues[property];

                                    // TODO: decide which value should be written to database
                                    // proposedValues[property] = <value to be saved>;
                                }

                                // Refresh original values to bypass next concurrency check


                                // UserWIN -> Original auf DB setzen -> löst den konflikt
                                // entry.OriginalValues.SetValues(databaseValues);

                                // DBWin ->
                                entry.CurrentValues.SetValues(databaseValues);
                                entry.OriginalValues.SetValues(databaseValues);
                                var oldState = entry.State;
                                entry.State = EntityState.Unchanged;
                            }
                            else
                            {
                                throw new NotSupportedException(
                                    "Don't know how to handle concurrency conflicts for "
                                    + entry.Metadata.Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
