using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.ProjectAli.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.ProjectAli.Data.EF.Tests
{
    [TestClass]
    public class EFContextTests
    {
        [TestMethod]
        public void EFContext_can_create_Context()
        {
            EFContext context = new EFContext();

            // Testfälle prüfen
            // Assert.IsNotNull(context);
            context.Should().NotBeNull();
        }

        // testm + TAB + TAB
        [TestMethod]
        public void EFContext_Can_Insert_Airport()
        {
            Airport a = new Airport { Latitude = 10, Longitude = 10, Elevation = 10, Decode = "Vienna",Iata="VIE",LocInt="LOWW" };
            using (EFContext context = new EFContext())
            {
                context.Airport.Add(a);
                context.SaveChanges(); // generiert beim INSERT die ID
            }

            // Testen ob es auch in der DB ist
            using (EFContext context = new EFContext()) // Damit es nicht aus dem Cache kommt ;)
            {
                var loadedAirport = context.Airport.Find(a.ID);
                Assert.AreEqual(a.Iata, loadedAirport.Iata);
                // <--- Ziel wäre: jedes einzelne Property prüfen
            }
        }

        // ----------- Hilfe für Tests --------------
        // Autofixture:         Generieren von Testdaten
        // FluentAssertions:    Bessere Asserts

        [TestMethod]
        public void EFContext_Can_Insert_Airport_Fluent()
        {
            Airport a = new Airport { Latitude = 10, Longitude = 10, Elevation = 10, Decode = "Vienna", Iata = "VIE", LocInt = "LOWW" };
            using (EFContext context = new EFContext())
            {
                context.Airport.Add(a);
                context.SaveChanges(); // generiert beim INSERT die ID
            }

            // Testen ob es auch in der DB ist
            using (EFContext context = new EFContext()) // Damit es nicht aus dem Cache kommt ;)
            {
                var loadedAirport = context.Airport.Find(a.ID);
                // Assert.AreEqual(a.Iata, loadedAirport.Iata);
                loadedAirport.Should().BeEquivalentTo(a);  // <--- Jedes einzelne Property prüfen
            }
        }

        [TestMethod]
        public void EFContext_Can_Insert_Airport_Fluent_Autofixture()
        {
            Fixture fix = new Fixture();
            Airport a = fix.Build<Airport>()
                           .Without(x => x.ID)
                           .Without(x => x.Iata)
                           .Without(x => x.LocInt)
                           .Create();
            a.Iata = fix.Create<string>().Substring(0, 3);
            a.LocInt = fix.Create<string>().Substring(0, 4);

            using (EFContext context = new EFContext())
            {
                context.Airport.Add(a);
                context.SaveChanges(); // generiert beim INSERT die ID
            }

            // Testen ob es auch in der DB ist
            using (EFContext context = new EFContext()) // Damit es nicht aus dem Cache kommt ;)
            {
                var loadedAirport = context.Airport.Find(a.ID);
                // Assert.AreEqual(a.Iata, loadedAirport.Iata);
                loadedAirport.Should().BeEquivalentTo(a);  // <--- Jedes einzelne Property prüfen
            }
        }


        [TestMethod]
        public void EFContext_Can_Insert_Airport_with_wrong_Iata_throws_Exception()
        {
            Fixture fix = new Fixture();
            Airport a = fix.Build<Airport>()
                           .Without(x => x.ID)
                           .Without(x => x.Iata)
                           .Without(x => x.LocInt)
                           .Create();
            a.LocInt = "ABCD"; //gültig
            a.Iata = "sehrfalscherIATACode";   // absichtlich ungültig

            using (EFContext context = new EFContext())
            {
                context.Airport.Add(a);
                context.Invoking(x => x.SaveChanges()).Should().Throw<DbUpdateException>();
            }
        }


        [TestMethod]
        public void Autofixture_Demo()
        {
            Fixture fix = new Fixture();
            var demo = fix.Create<Airport>();
            var demo2 = fix.CreateMany<Airport>(1000).ToArray();

            var flight = fix.Create<Airline>();
        }
    }

    class Airline
    {
        public List<Flight> CurrentFlights { get; set; }
    }
}
