//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hallo_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kunde : Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kunde()
        {
            this.Schuhgröße = new Schuhgröße();
        }
    
        public string Kundennummer { get; set; }
        public string Haarfarbe { get; set; }
    
        public Schuhgröße Schuhgröße { get; set; }
    
        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }
}