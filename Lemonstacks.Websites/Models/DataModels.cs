using System.ComponentModel.DataAnnotations;

namespace Lemonstacks.Websites.Models
{
    public class DataModels
    {
        public string? FullName { get; set; }
        public string? MobilePhone { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "กรุณากรอกอีเมล")]
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Detail { get; set; }
        public string? Service { get; set; }
    }
}
