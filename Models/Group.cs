using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
