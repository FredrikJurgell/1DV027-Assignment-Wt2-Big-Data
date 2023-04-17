using assignment_wt2_oauth;
using Elasticsearch.Net;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using DotNetEnv;

DotNetEnv.Env.Load();
string elasticPassword = Environment.GetEnvironmentVariable("ELASTIC_PASSWORD");
var connectionSettings = new ConnectionSettings(new Uri("https://localhost:9200"));
connectionSettings.DisableDirectStreaming();
connectionSettings.BasicAuthentication("elastic", elasticPassword);
connectionSettings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);

var elasticClient = new ElasticClient(connectionSettings);

var serviceProvider = new ServiceCollection()
    .AddSingleton<IImdbData, ImdbData>()
    .AddSingleton<AddToElastic>()
    .AddSingleton<IElasticClient>(elasticClient)
    .BuildServiceProvider();

var ImdbData = serviceProvider.GetService<IImdbData>();
var addToElastic = serviceProvider.GetService<AddToElastic>();

var data = await ImdbData.GetData();

await addToElastic.AddData(data);