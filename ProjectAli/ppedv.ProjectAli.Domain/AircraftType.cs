﻿namespace ppedv.ProjectAli.Domain
{
    public class AircraftType : Entity
    {
        public string Code { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public WTC WTC { get; set; }
    }

}
