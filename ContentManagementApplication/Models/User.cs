using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContentManagementApplication.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
    }
}
