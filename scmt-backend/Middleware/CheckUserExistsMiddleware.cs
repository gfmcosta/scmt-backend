using Microsoft.AspNetCore.Identity;

public class CheckUserExistsMiddleware
{
    private readonly RequestDelegate _next;

    public CheckUserExistsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user == null)  // User doesn't exist anymore
            {
                await signInManager.SignOutAsync();  // Log out the user
                context.Response.Redirect("/");  // Redirect to login page
                return;
            }
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}