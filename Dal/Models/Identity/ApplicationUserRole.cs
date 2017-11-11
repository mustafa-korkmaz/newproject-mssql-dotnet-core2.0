using System;
using Microsoft.AspNetCore.Identity;

namespace Dal.Models.Identity
{
    public class ApplicationUserRole<T> : IdentityUserRole<T> where T : IEquatable<T>
    {
    }
}
