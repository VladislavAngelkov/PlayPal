using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace PlayPal.Core.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IRepository _repository;
        private readonly UserManager<PlayPalUser> _userManager;

        public AdministratorService(
            IRepository repository,
            UserManager<PlayPalUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task CreateAdministrator(RegisterUserInputModel model)
        {
            var administrator = new Administrator()
            {
                Id = model.Administrator!.Id,
                FirstName = model.Administrator.FirstName,
                LastName = model.Administrator.LastName,
                UserId = model.Id
            };

            await _repository.AddAsync<Administrator>(administrator);
        }

        public async Task<ICollection<ApplicationAdministratorViewModel>> GetAdministratorApplicationsAsync()
        {
            var administrators = await _userManager
                .Users
                .Where(u => u.Administator != null)
                .AsNoTracking()
                .ToListAsync();

            var administratorsApplications = new List<ApplicationAdministratorViewModel>();

            foreach (var administrator in administrators)
            {
                if (!await _userManager.IsInRoleAsync(administrator, "Administrator"))
                {
                    var application = new ApplicationAdministratorViewModel()
                    {
                        AdministratorId = administrator.AdministratorId,
                        Email = administrator.Email
                    };

                    administratorsApplications.Add(application);
                }
            }

            return administratorsApplications;
        }

        public async Task PromoteUserToAdministrator(string email, Guid administratorId)
        {
            var user = await _userManager.FindByEmailAsync(email);

            await _userManager.AddToRoleAsync(user, "Administrator");

            var claim = new Claim("AdministratorId", administratorId.ToString());
            
            await _userManager.AddClaimAsync(user, claim);
        }
    }
}
