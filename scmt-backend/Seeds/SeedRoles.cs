using Microsoft.AspNetCore.Identity;

namespace scmt_backend.Seeds;

public class SeedRoles
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
        string[] roleNames = { "Admin", "User", "Manager" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                // Create the roles and seed them to the database
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (roleResult.Succeeded)
                {
                    Console.WriteLine($"Role '{roleName}' created successfully.");
                }
                else
                {
                    Console.WriteLine($"Error creating role '{roleName}': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
