using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PlayPal.Data.Models;

namespace PlayPal.Data.Seeding
{
    public class EntityGenerator 
    {
        public ICollection<PlayPalRole> GenerateRoles()
        {
            var roleGuids = File.ReadAllLines("../PlayPal.Data/Seeding/SeedingData/RoleGuids.txt");

            var roles = new List<PlayPalRole>();

            var adminRole = new PlayPalRole();
            adminRole.Name = "Admin";
            adminRole.NormalizedName = adminRole.Name.ToUpper();
            adminRole.Id = Guid.Parse(roleGuids[0]);
            roles.Add(adminRole);

            var fieldOwnerRole = new PlayPalRole();
            fieldOwnerRole.Name = "FieldOwner";
            fieldOwnerRole.NormalizedName = fieldOwnerRole.Name.ToUpper();
            fieldOwnerRole.Id = Guid.Parse(roleGuids[1]);
            roles.Add(fieldOwnerRole);

            var playerRole = new PlayPalRole();
            playerRole.Name = "Player";
            playerRole.NormalizedName = playerRole.Name.ToUpper();
            playerRole.Id = Guid.Parse(roleGuids[2]);
            roles.Add(playerRole);

            return roles;
        }

        public ICollection<IdentityUserRole<Guid>> GenerateUserRoles()
        {
            var userGuids = File.ReadAllLines("../PlayPal.Data/Seeding/SeedingData/UserGuids.txt");

            var roleGuids = File.ReadAllLines("../PlayPal.Data/Seeding/SeedingData/RoleGuids.txt");

            var userRoles = new List<IdentityUserRole<Guid>>();

            var userRoleAdmin = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse(userGuids[0]),
                RoleId = Guid.Parse(roleGuids[0])
            };
            userRoles.Add(userRoleAdmin);

            var userFieldOwnerRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse(userGuids[1]),
                RoleId = Guid.Parse(roleGuids[1])
            };
            userRoles.Add(userFieldOwnerRole);

            var userPlayerRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse(userGuids[2]),
                RoleId = Guid.Parse(roleGuids[2])
            };
            userRoles.Add(userPlayerRole);

            return userRoles;
        }

        public ICollection<PlayPalUser> GenerateUsers()
        {
            var userGuids = File.ReadAllLines("../PlayPal.Data/Seeding/SeedingData/UserGuids.txt");

            string password = "Password";

            var passwordHasher = new PasswordHasher<PlayPalUser>();

            var users = new List<PlayPalUser>();

            var admin = new PlayPalUser()
            {
                Id = Guid.Parse(userGuids[0]),
                Email = "Administrator@test.com",
                UserName = "Administrator@test.com"
            };
            admin.NormalizedEmail = admin.Email.ToUpper();
            admin.NormalizedUserName = admin.UserName.ToUpper();
            admin.PasswordHash = passwordHasher.HashPassword(admin, password);
            admin.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(admin);

            var fieldOwner = new PlayPalUser()
            {
                Id = Guid.Parse(userGuids[1]),
                Email = "FieldOwner@test.com",
                UserName = "FieldOwner@test.com"
            };
            fieldOwner.NormalizedEmail = fieldOwner.Email.ToUpper();
            fieldOwner.NormalizedUserName = fieldOwner.UserName.ToUpper();
            fieldOwner.PasswordHash = passwordHasher.HashPassword(fieldOwner, password);
            fieldOwner.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(fieldOwner);

            var player = new PlayPalUser()
            {
                Id = Guid.Parse(userGuids[2]),
                Email = "Player@test.com",
                UserName = "Player@test.com"
            };
            player.NormalizedEmail = player.Email.ToUpper();
            player.NormalizedUserName = player.UserName.ToUpper();
            player.PasswordHash = passwordHasher.HashPassword(player, password);
            player.SecurityStamp = Guid.NewGuid().ToString();
            users.Add(player);


            return users;
        }

        public ICollection<T> GenerateEntity<T>()
        {
            var entityName = typeof(T).Name;

            var path = $"../PlayPal.Data/Seeding/SeedingData/{entityName}Data.json";

            var entityText = File.ReadAllText(path);

            var entities = JsonConvert.DeserializeObject<ICollection<T>>(entityText);

            return entities;
        }
    }
}
