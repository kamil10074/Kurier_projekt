using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurier_projekt.Models
{
    public class Kurierzy
    {
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Imie")]
        public string Imie { get; set; }

        [Column("Nazwisko")]
        [Display(Name = "Nazwisko")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Nazwisko { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data urodzenia")]
        public DateTime Data_urodzenia { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data zatrudnienia")]
        public DateTime Data_zatrudnienia { get; set; }

        [Column("Adres")]
        [Display(Name = "Adres")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Adres { get; set; }


        [Display(Name = "Imie i nazwisko")]
        public string FullName
        {
            get
            {
                return Imie + ", " + Nazwisko;
            }
        }


    }
}