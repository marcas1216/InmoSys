
namespace Properties.Entities.Read
{
    public class LoadPropertyTypes
    {
        public int ptyId { get; set; }
        public string ptyName { get; set; } = string.Empty;
        public string ptyDescription { get; set; } = string.Empty;
        public DateTime ptyRegisterDate { get; set; }
        public int ptyState { get; set; }
    }
}
