namespace Projet_6_Modelisez_et_créez_une_base_de_données.Models.Entities
{
    public class Configuration
    {
        public int Id { get; set; }
        public int AppVersionId { get; set; }
        public AppVersion AppVersion { get; set; } = null!;
        public int OpeSysId { get; set; }
        public OpeSys OpeSys { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public IList<Ticket> Tickets { get; set; }

        public Configuration()
        {
            Tickets = [];
        }

    }
}
