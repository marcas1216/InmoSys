
namespace Properties.Entities.Read
{
    public class LoadProperty
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? RegisterDate { get; set; }
        public int State { get; set; }
    }
}
