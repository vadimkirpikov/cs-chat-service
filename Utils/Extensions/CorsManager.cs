namespace ChatService.Utils.Extensions;

public static class CorsManager
{
    public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder, string policyName)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyOrigin();
            });
        });
        return builder;
    }
}