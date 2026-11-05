namespace Projet_6_Modelisez_et_créez_une_base_de_données.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Configuration> Configurations { get; set; }

        public Product()
        {
            Configurations = [];
        }

    }
}
