using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.ProjectAli.Domain;
using ppedv.ProjectAli.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.ProjectAli.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            #region Testdaten
            Airport departure = new Airport();
            departure.LocInt = "LOWW";
            departure.Decode = "Vienna";
            departure.Iata = "VIE";
            departure.Latitude = 48.110298156738;
            departure.Longitude = 16.569700241089;
            departure.Elevation = 600;

            Airport expectedResult = new Airport();
            expectedResult.LocInt = "EGLL";
            expectedResult.Decode = "London Heathrow Airport";
            expectedResult.Iata = "LHR";
            expectedResult.Latitude = 51.4706;
            expectedResult.Longitude = -0.461941;
            expectedResult.Elevation = 83;

            Airport expectedResult2 = new Airport();
            expectedResult2.LocInt = "EDDF";
            expectedResult2.Decode = "Frankfurt Airport";
            expectedResult2.Iata = "FRA";

            Airport wrongResult = new Airport();
            wrongResult.LocInt = "LIMF";
            wrongResult.Decode = "Turin Airport";
            wrongResult.Iata = "TRN";
            wrongResult.Latitude = 45.200802;
            wrongResult.Longitude = 7.46963;
            wrongResult.Elevation = 989;

            List<Flight> flights = new List<Flight>
            {
                new Flight
                {
                Departure = departure,
                Destination = expectedResult,
                Duration = TimeSpan.FromMinutes(150),
                AircraftID = "DLH123",
                },
                new Flight
                {
                Departure = wrongResult,
                Destination = departure,
                Duration = TimeSpan.FromMinutes(240), // Mit Rückenwind
                AircraftID = "OEADS",
                },
                new Flight
                {
                Departure = departure,
                Destination = expectedResult2,
                Duration = TimeSpan.FromMinutes(150),
                AircraftID = "DLH123",
                },
            };
            // Flug mit Index 0 ist das erwartete Ergebnis
            #endregion

            // Abhängigkeiten loswerden: https://github.com/Moq/moq4/wiki/Quickstart
            Mock<IRepository> dbfake = new Mock<IRepository>();
            dbfake.Setup(x => x.Query<Flight>())
                  .Returns(() => flights.AsQueryable());

            Core core = new Core(dbfake.Object); // Fake-DB hineinlegen

            var result = core.GetAllDestinationsFrom(departure);
            // Dank unseres Fakes geht der Befehl durch unsere Testliste "flights" durch

            result.Should().Contain(expectedResult);
            result.Should().Contain(expectedResult2);
            result.Should().NotContain(departure);      // er darf nicht zu sich selbst fliegen
            result.Should().NotContain(wrongResult);    // der Flughafen wird nicht angeflogen
        }
    }
}
