namespace CaseExsitec.Models
{
    public class LagersaldoModel
    {
        public int Id { get; set; }
        public string? Produkt { get; set; }
        public string? Varelager { get; set; }
        public int Lagersaldo { get; set; }

        public LagersaldoModel()
        {

        }
    }
}
