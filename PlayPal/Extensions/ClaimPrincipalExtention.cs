using Microsoft.CodeAnalysis.CSharp.Syntax;
using PlayPal.Common.IdentityConstants;
using System.Security.Claims;

namespace PlayPal.Extensions
{
    public static class ClaimPrincipalExtention
    {
        public static Guid UserId(this ClaimsPrincipal claimsPrincipal)
        {
            Guid userId = Guid.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));

            return userId;
        }

        public static Guid? OwnerId(this ClaimsPrincipal claimsPrincipal)
        {
            Claim? claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.FieldOwnerId);

            if (claim == null)
            {
                return null;
            }

            return Guid.Parse(claim.Value);
        }

        public static Guid? AdministratorId(this ClaimsPrincipal claimsPrincipal)
        {

            Claim? claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.AdministratorId);

            if (claim == null)
            {
                return null;
            }

            return Guid.Parse(claim.Value);
        }

        public static Guid? PlayerId(this ClaimsPrincipal claimsPrincipal)
        {

            Claim? claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.PlayerId);

            if (claim == null)
            {
                return null;
            }

            return Guid.Parse(claim.Value);
        }
    }
}
