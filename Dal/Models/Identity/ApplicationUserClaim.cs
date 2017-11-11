using System;
using Microsoft.AspNetCore.Identity;

namespace Dal.Models.Identity
{
    public class ApplicationUserClaim<T> : IdentityUserClaim<T> where T : IEquatable<T>
    {
    }
}
