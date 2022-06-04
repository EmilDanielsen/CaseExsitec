using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CaseExsitec.Models
{
    public class InnOgUtleveranse
    {
        public int Id { get; set; }
        public string? Dato { get; set; }
        public string? Produkt { get; set; }
        
        [DisplayName("Til/fra")]
        public string? TilFra { get; set; }
        public int Antall { get; set; }

        [DisplayName("Inngående lagersaldo")]
        public bool InngåendeLagersaldo { get; set; }

       
        public InnOgUtleveranse()
        {

        }

    }
}
