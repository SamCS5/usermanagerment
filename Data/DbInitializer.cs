using System.Diagnostics;
using UserApplication.Models;

namespace UserApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserApplicationContext context)
        {
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{FirstName="Carson",LastName="Alexander"},
                new User{FirstName="Meredith",LastName="Alonso"},
                new User{FirstName="Arturo",LastName="Anand"},
                new User{FirstName="Gytis",LastName="Barzdukas"},
                new User{FirstName="Yan",LastName="Li"},
                new User{FirstName="Peggy",LastName="Justice"},
                new User{FirstName="Laura",LastName="Norman"},
                new User{FirstName="Nino",LastName="Olivetto"}
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var groups = new Group[]
            {
                new Group{GroupId=1050,GroupName="Group 1"},
                new Group{GroupId=2024,GroupName="Group 2"},
                new Group{GroupId=3055,GroupName="Group 3"},
                new Group{GroupId=4022,GroupName="Group 4"},
                new Group{GroupId=5051,GroupName="Group 5" }            
            };

            context.Groups.AddRange(groups);
            context.SaveChanges();

            var permissions = new Permission[]
            {
                new Permission{UserId=1,GroupId=1050,UserPermissions=UserPermissions.A},
                new Permission{UserId=1,GroupId=4022,UserPermissions=UserPermissions.C},
                new Permission{UserId=1,GroupId=3055,UserPermissions=UserPermissions.B},
                new Permission{UserId=2,GroupId=3055,UserPermissions=UserPermissions.B},
                new Permission{UserId=2,GroupId=5051,UserPermissions=UserPermissions.A},
                new Permission{UserId=2,GroupId=2024,UserPermissions=UserPermissions.A},
                new Permission{UserId=3,GroupId=5051},
                new Permission{UserId=4,GroupId=1050},
                new Permission{UserId=4,GroupId=4022,UserPermissions=UserPermissions.C}
               
            };

            context.Permissions.AddRange(permissions);
            context.SaveChanges();
        }
    }
}
