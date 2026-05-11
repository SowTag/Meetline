var builder = DistributedApplication.CreateBuilder(args);

var clerkApiKey = builder.AddParameterFromConfiguration("clerk-api-key", "Clerk:ApiKey", secret: true);

var postgres = builder.AddPostgres("postgres-master")
    .WithDataVolume();

var usersPostgres = postgres.AddDatabase("postgres-users");
var rolesPostgres = postgres.AddDatabase("postgres-roles");

builder.AddProject<Projects.Web>("meetline-backend")
    .WithReference(usersPostgres)
    .WithReference(rolesPostgres)
    .WithEnvironment("Clerk__ApiKey", clerkApiKey)
    .WaitFor(postgres);

builder.Build().Run();