﻿using PlayPal.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace PlayPal.Core.Models.InputModels
{
    public class RegisterUserInputModel
    {
        public RegisterUserInputModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public CreatePlayerInputModel? Player { get; set; }

        public CreateAdministratorInputModel? Administrator { get; set; }

        public CreateFieldOwnerInputModel? FieldOwner { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PlayPalUserConstants.PasswordMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
