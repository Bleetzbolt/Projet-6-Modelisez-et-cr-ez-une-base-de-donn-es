namespace Projet_6_Modelisez_et_créez_une_base_de_données.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateOnly? CreationDate { get; set; } = null;
        public DateOnly? ResolutionDate { get; set; } = null;
        public bool IsResolved { get; set; }
        public String? ProblemDescription { get; set; } = null;
        public String? ResolutionDescription { get; set; } = null;
        public int ConfigurationId { get; set; }
        public Configuration Configuration { get; set; } = null!;
        

    }
}
