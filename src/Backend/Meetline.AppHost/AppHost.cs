var builder = DistributedApplication.CreateBuilder(args);

var clerkApiKey = builder.AddParameterFromConfiguration("clerk-api-key", "Clerk:ApiKey", secret: true);
var clerkWebhookSecret =
    builder.AddParameterFromConfiguration("clerk-webhook-secret", "Clerk:WebhookSecret", secret: true);
var clerkPublishableKey = builder.AddParameterFromConfiguration("clerk-publishable-key", "Clerk:PublishableKey");

var postgres = builder.AddPostgres("postgres-master")
    .WithDataVolume();

var usersPostgres = postgres.AddDatabase("postgres-users");
var rolesPostgres = postgres.AddDatabase("postgres-roles");



var backend = builder.AddProject<Projects.Web>("meetline-backend")
    .WithReference(usersPostgres)
    .WithReference(rolesPostgres)
    .WithEnvironment("Clerk__ApiKey", clerkApiKey)
    .WithEnvironment("Clerk__WebhookSecret", clerkWebhookSecret)
    .WaitFor(postgres);

var frontend = builder.AddViteApp("frontend", "../../Frontend/MeetlineUI")
    .WithPnpm()
    .WithEnvironment("VITE_CLERK_PUBLISHABLE_KEY", clerkPublishableKey)
    .WithEnvironment("VITE_API_BASE_URL", backend.GetEndpoint("https"))
    .WithReference(backend)
    .WaitFor(backend);

builder.Build().Run();