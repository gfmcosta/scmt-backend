using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace scmt_backend.Seeds
{
    public static class SeedUsers
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Criar utilizadores se ainda não existirem
            await CreateDefaultUser(userManager, "aluno23692@ipt.pt", "123Qwe#", "Admin");
            await CreateDefaultUser(userManager, "aluno23882@ipt.pt", "123Qwe#", "Manager");
            await CreateDefaultUser(userManager, "gfmcosta03@gmail.com", "123Qwe#", "User");
        }

        private static async Task CreateDefaultUser(UserManager<IdentityUser> userManager, string email, string password, string roleName)
        {
            // Verificar se o utilizador já existe
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Criar um novo utilizador
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true // Defina como true se não quiser confirmação de email
                };

                var result = await userManager.CreateAsync(user, password);

                // Se o utilizador foi criado com sucesso, atribuir o role
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                    Console.WriteLine($"Utilizador '{email}' criado e atribuído ao role '{roleName}'.");
                }
                else
                {
                    Console.WriteLine($"Erro ao criar utilizador '{email}': {string.Join(", ", result.Errors)}");
                }
            }
            else
            {
                Console.WriteLine($"Utilizador '{email}' já existe.");
            }
        }
    }
}
