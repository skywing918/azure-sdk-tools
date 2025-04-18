// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AzureRAGService;
using Hubbup.MikLabelModel;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<ITriageRAG, TriageRAG>();
        services.AddSingleton<IModelHolderFactoryLite, ModelHolderFactoryLite>();
        services.AddSingleton<ILabelerLite, LabelerLite>();
        var config = context.Configuration;
        services.AddSingleton(config);
    })
    .Build();

host.Run();
