
namespace Owner.Entities.Read
{
    public  class AllOwners
    {
        public int OId { get; set; }
        public string? OFirstName { get; set; } = string.Empty;
        public string? OLastName { get; set; } = string.Empty;
        public string? ODocumentType { get; set; } = string.Empty;
        public string? ODocument { get; set; } = string.Empty;
        public string? OEmail { get; set; } = string.Empty;
        public string? OAddress { get; set; } = string.Empty;
        public string? OCity { get; set; } = string.Empty;
        public string? OState { get; set; } = string.Empty;
        public string? OCountry { get; set; } = string.Empty;
        public string? OPhoto { get; set; } = string.Empty;
        public DateTime? OBirthDate { get; set; }
        public string? OPhone { get; set; }
        public DateTime ORegisterDate { get; set; }
        public int OStateRegister { get; set; }
    }
}
