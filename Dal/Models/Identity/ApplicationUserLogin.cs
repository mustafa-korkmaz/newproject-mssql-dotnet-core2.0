using System;
using Microsoft.AspNetCore.Identity;

namespace Dal.Models.Identity
{
    public class ApplicationUserLogin<T> : IdentityUserLogin<T> where T : IEquatable<T>
    {
    }
}
