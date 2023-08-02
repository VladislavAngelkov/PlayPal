using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.ViewModels
{
    public class FieldOwnerProfileViewModel
    {
        public Guid Id { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string FirstName { get; set; } = null!;
       
        public string LastName { get; set; } = null!;
       
        public string CompanyName { get; set; } = null!;
       
        public string Title { get; set; } = null!;
       
        public string ContactAddress { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
