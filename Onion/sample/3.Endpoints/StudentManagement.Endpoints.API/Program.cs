﻿using StudentManagement.Endpoints.API.Extentions;
using StudentManagement.Endpoints.API.Extentions.DependencyInjection.IdentityServer.Extentions;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder
    .AddZaminSerilog(o =>
    {
        o.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName");
        o.ServiceId = builder.Configuration.GetValue<string>("ServiceId");
        o.ServiceName = builder.Configuration.GetValue<string>("ServiceName");
        o.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion");
    })
    .ConfigureServices().ConfigurePipeline();
    app.UseIdentityServer("OAuth");
    app.Run();
});