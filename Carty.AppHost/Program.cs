var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.Carty_Customer>("customer").WithExternalHttpEndpoints();

builder.Build().Run();
