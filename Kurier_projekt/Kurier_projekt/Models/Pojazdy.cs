//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurier_projekt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pojazdy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pojazdy()
        {
            this.Kurierzy = new HashSet<Kurierzy>();
        }
    
        public int Id_pojazdu { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Rok_produkcji { get; set; }
        public string Numer_rejestracyjny { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kurierzy> Kurierzy { get; set; }
    }
}