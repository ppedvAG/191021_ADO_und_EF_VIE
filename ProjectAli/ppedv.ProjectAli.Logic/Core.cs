﻿using ppedv.ProjectAli.Domain;
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
            this.Repository = repo;
        }

        public IRepository Repository { get; private set; }


        public void GenerateDemoData()
        {
            if (Repository.Query<AircraftType>().Count() > 0)
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
            a1.SupportedWTC = WTC.L | WTC.M | WTC.H | WTC.X;

            Airport a2 = new Airport();
            a2.LocInt = "EGLL";
            a2.Decode = "London Heathrow Airport";
            a2.Iata = "LHR";
            a2.Latitude = 51.4706;
            a2.Longitude = -0.461941;
            a2.Elevation = 83;
            a2.SupportedWTC = WTC.L | WTC.M | WTC.H | WTC.X;


            Airport a3 = new Airport();
            a3.LocInt = "LIMF";
            a3.Decode = "Turin Airport";
            a3.Iata = "TRN";
            a3.Latitude = 45.200802;
            a3.Longitude = 7.46963;
            a3.Elevation = 989;
            a3.SupportedWTC = WTC.L | WTC.M | WTC.H;


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

            Repository.Add(f1);
            Repository.Add(f2);
            Repository.Add(f3);

            Repository.Save();
        }

        public Airport[] GetAllDestinationsFrom(Airport departureAirport)
        {
            // .... was kann man von z.B. Wien alles anfliegen ?

            return Repository.Query<Flight>().Where(x => x.Departure.LocInt == departureAirport.LocInt)
                                       .Select(x => x.Destination)
                                       .ToArray();
        }

        public Airport[] GetAllAirportsFor(AircraftType aircraft)
        {
            return Repository.Query<Airport>().Where(x => x.SupportedWTC.HasFlag(aircraft.WTC))
                                        .ToArray();
        }

        public AircraftType[] GetAllAircraft()
        {
            return Repository.GetAll<AircraftType>().ToArray();
        }
        public Airport[] GetAllAirports()
        {
            return Repository.GetAll<Airport>().ToArray();
        }
    }
}
