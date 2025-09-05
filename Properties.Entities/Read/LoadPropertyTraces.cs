
namespace Properties.Entities.Read
{
    public class LoadPropertyTraces
    {    
        public DateTime phtDateSale { get; set; }
        public string phtName { get; set; } = string.Empty;
        public decimal phtValue { get; set; }
        public decimal ptrTax { get; set; }
        public int ptrPropertyId { get; set; }       
    }
}
