using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.ProjectAli.Logic
{
    // Programmkern -> Gesamte Geschäftslogik der Applikation
    public class Core
    {
        public Core(IRepository repo)
        {
            this.repo = repo;
        }

        private IRepository repo;


        public void GenerateDemoData()
        {
            if (repo.Query<AircraftType>().Count() > 0)
                return; // Mach nix

            AircraftType at1 = new AircraftType();
            at1.Code = "C100";
            at1.Model = "Cessna";
            at1.Manufacturer = "Cessna";
            at1.WTC = WTC.L;

            AircraftType at2 = new AircraftType();
            at2.Code = "B735";
            at2.Model = "Boeing 737-500";
            at2.Manufacturer = "Boeing";
            at2.WTC = WTC.H;

            AircraftType at3 = new AircraftType();
            at3.Code = "A380";
            at3.Model = "Airbus 380";
            at3.Manufacturer = "Airbus";
            at3.WTC = WTC.X;

            Airport a1 = new Airport();
            a1.LocInt = "LOWW";
            a1.Decode = "Vienna";
            a1.Iata = "VIE";
            a1.Latitude = 48.110298156738;
            a1.Longitude = 16.569700241089;
            a1.Elevation = 600;

            Airport a2 = new Airport();
            a2.LocInt = "EGLL";
            a2.Decode = "London Heathrow Airport";
            a2.Iata = "LHR";
            a2.Latitude = 51.4706;
            a2.Longitude = -0.461941;
            a2.Elevation = 83;

            Airport a3 = new Airport();
            a3.LocInt = "LIMF";
            a3.Decode = "Turin Airport";
            a3.Iata = "TRN";
            a3.Latitude = 45.200802;
            a3.Longitude = 7.46963;
            a3.Elevation = 989;

            Flight f1 = new Flight();
            f1.Departure = a1;
            f1.Destination = a2;
            f1.Duration = TimeSpan.FromMinutes(150);
            f1.AircraftID = "DLH123";
            f1.AircraftType = at2;

            Flight f2 = new Flight();
            f2.Departure = a3;
            f2.Destination = a1;
            f2.Duration = TimeSpan.FromMinutes(240); // Mit Rückenwind
            f2.AircraftID = "OEADS";
            f2.AircraftType = at1;

            Flight f3 = new Flight();
            f3.Departure = a2;
            f3.Destination = a3;
            f3.Duration = TimeSpan.FromMinutes(240); 
            f3.AircraftID = "BAW987";
            f3.AircraftType = at3;

            repo.Add(f1);
            repo.Add(f2);
            repo.Add(f3);

            repo.Save()
        }

        public Airport[] GetAllDestinationsFrom(Airport departureAirport)
        {
            // .... was kann man von z.B. Wien alles anfliegen ?

            return repo.Query<Flight>().Where(x => x.Destination.LocInt == departureAirport.LocInt)
                                       .Select(x => x.Destination)
                                       .ToArray();

        }
    }
}
