var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeWave_Gateway>("codewave-gateway");

builder.AddProject<Projects.CodeWave_Authentication>("codewave-authentication");

builder.Build().Run();
