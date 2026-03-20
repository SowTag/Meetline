using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Web.Configs;

public static class OpenApiConfiguration
{
    public static void Configure(OpenApiOptions options)
    {
        options.AddDocumentTransformer((document, _, _) =>
        {
            document.Info.Title = "Meetline";
            document.Info.Version = "v0.0.1";
            document.Info.Description = "Meetline is an online learning and conferencing app.";

            document.Info.Contact = new OpenApiContact
            {
                Name = "Maddock",
                Email = "sowtag@gmail.com",
                Url = new Uri("https://github.com/SowTag")
            };

            return Task.CompletedTask;
        });
    }
}