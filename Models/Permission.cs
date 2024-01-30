using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace UserApplication.Models
{
    public enum UserPermissions
    {
        A,B,C
    }
    public class Permission
    {
        public int PermissionId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        [DisplayFormat(NullDisplayText = "No rank")]
        public UserPermissions? UserPermissions { get; set; }

        public Group Group { get; set; }
        public User User { get; set; }
    }
}
