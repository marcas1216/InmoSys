
namespace Properties.Entities.Write
{
    public class AddProperty
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int OwnerId { get; set; }
        public int PropertyTypeId { get; set; }
        public int PropertyStateId { get; set; }
    }
}
