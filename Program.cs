using assignment_wt2_oauth;
using Elasticsearch.Net;
using Microsoft.Extensions.DependencyInjection;
using Nest;


/// <summary>
/// This code connects to an Elasticsearch instance and adds data retrieved from the IMDB API.
/// </summary>

DotNetEnv.Env.Load();
string elasticPassword = Environment.GetEnvironmentVariable("ELASTIC_PASSWORD");

// Set up a connection to Elasticsearch
var connectionSettings = new ConnectionSettings(new Uri("https://localhost:9200"));
connectionSettings.DisableDirectStreaming();
connectionSettings.BasicAuthentication("elastic", elasticPassword);
connectionSettings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);

var elasticClient = new ElasticClient(connectionSettings);

// Set up a dependency injection container
var serviceProvider = new ServiceCollection()
    .AddSingleton<IImdbData, ImdbData>()
    .AddSingleton<AddToElastic>()
    .AddSingleton<IElasticClient>(elasticClient)
    .BuildServiceProvider();

// Retrieve an instance of the IMDB data service and the Elasticsearch data loader
/// <summary>
/// Implements IImdbData interface to provide access to IMDB data.
/// </summary>
var ImdbData = serviceProvider.GetService<IImdbData>();

/// <summary>
/// Implements AddData method to load data into Elasticsearch.
/// </summary>
var addToElastic = serviceProvider.GetService<AddToElastic>();

// Retrieve data from the IMDB API and load it into Elasticsearch
var data = await ImdbData.GetData();

await addToElastic.AddData(data);