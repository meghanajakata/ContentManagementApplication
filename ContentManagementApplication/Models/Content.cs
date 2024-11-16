using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContentManagementApplication.Models
{
    public class Content
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
