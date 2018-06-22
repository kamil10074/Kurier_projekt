using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurier_projekt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pojazdy
    {
        public int Id_pojazdu { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Marka { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Model { get; set; }
        public int Rok_produkcji { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Numer_rejestracyjny { get; set; }
    }
}
