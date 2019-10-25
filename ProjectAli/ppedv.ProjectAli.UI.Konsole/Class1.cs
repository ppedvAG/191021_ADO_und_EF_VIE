using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.ProjectAli.UI.Konsole
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ArrayOfAirport
    {

        private ArrayOfAirportAirport[] airportField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Airport")]
        public ArrayOfAirportAirport[] Airport
        {
            get
            {
                return this.airportField;
            }
            set
            {
                this.airportField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfAirportAirport
    {

        private ushort idField;

        private bool isDeletedField;

        private System.DateTime creationDateField;

        private System.DateTime modifiedDateField;

        private System.DateTime deletedDateField;

        private string locIntField;

        private string decodeField;

        private string iataField;

        private decimal longitudeField;

        private decimal latitudeField;

        private ushort elevationField;

        private string supportedWTCField;

        /// <remarks/>
        public ushort ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public bool IsDeleted
        {
            get
            {
                return this.isDeletedField;
            }
            set
            {
                this.isDeletedField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CreationDate
        {
            get
            {
                return this.creationDateField;
            }
            set
            {
                this.creationDateField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ModifiedDate
        {
            get
            {
                return this.modifiedDateField;
            }
            set
            {
                this.modifiedDateField = value;
            }
        }

        /// <remarks/>
        public System.DateTime DeletedDate
        {
            get
            {
                return this.deletedDateField;
            }
            set
            {
                this.deletedDateField = value;
            }
        }

        /// <remarks/>
        public string LocInt
        {
            get
            {
                return this.locIntField;
            }
            set
            {
                this.locIntField = value;
            }
        }

        /// <remarks/>
        public string Decode
        {
            get
            {
                return this.decodeField;
            }
            set
            {
                this.decodeField = value;
            }
        }

        /// <remarks/>
        public string Iata
        {
            get
            {
                return this.iataField;
            }
            set
            {
                this.iataField = value;
            }
        }

        /// <remarks/>
        public decimal Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        public decimal Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        public ushort Elevation
        {
            get
            {
                return this.elevationField;
            }
            set
            {
                this.elevationField = value;
            }
        }

        /// <remarks/>
        public string SupportedWTC
        {
            get
            {
                return this.supportedWTCField;
            }
            set
            {
                this.supportedWTCField = value;
            }
        }
    }


}
