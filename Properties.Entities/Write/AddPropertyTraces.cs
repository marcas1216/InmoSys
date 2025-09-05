
namespace Properties.Entities.Write
{
    public class AddPropertyTraces
    {
        public int phtId { get; set; }
        public DateTime phtDateSale { get; set; }
        public string phtName { get; set; } = string.Empty;
        public decimal phtValue { get; set; }
        public decimal ptrTax { get; set; }
        public int ptrPropertyId { get; set; }
        public int ptrState { get; set; }
    }
}
