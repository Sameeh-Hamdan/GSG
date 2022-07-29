namespace Practice1.Web.Models
{
    public class Product:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageURL { get; set; }
    }
}
