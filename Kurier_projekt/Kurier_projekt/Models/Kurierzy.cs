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
    
    public partial class Kurierzy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kurierzy()
        {
            this.Przesyłki = new HashSet<Przesyłki>();
        }
    
        public int Id_Kurier { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public System.DateTime Data_urodzenia { get; set; }
        public System.DateTime Data_zatrudnienia { get; set; }
        public string Adres_kurier { get; set; }
        public int Id_Pojazdu { get; set; }
        public int Numer_telefonu { get; set; }
    
        public virtual Pojazdy Pojazdy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Przesyłki> Przesyłki { get; set; }
    }
}
