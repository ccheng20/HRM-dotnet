using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Entities;

// Admin, HR, Manager, Business analyst
public class Role: IdentityRole<Guid>
{
    public ICollection<UserRole> UsersForRole { get; set; }
}