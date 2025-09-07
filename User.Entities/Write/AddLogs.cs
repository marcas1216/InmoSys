
namespace User.Entities.Write
{
    public class AddLogs
    {      
        public string LModule { get; set; } = string.Empty;
        public string LMethod { get; set; } = string.Empty;
        public object  LRequest { get; set; } = string.Empty;
        public object LResponse { get; set; } = string.Empty;    
    }
}
