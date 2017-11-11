using System;
using Microsoft.AspNetCore.Identity;

namespace Dal.Models.Identity
{
    public class ApplicationRoleClaim<T> : IdentityRoleClaim<T> where T : IEquatable<T>
    {
    }
}
