namespace Practice02.Web.Models
{
    public class University:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsRecognized { get; set; }
    }
}
