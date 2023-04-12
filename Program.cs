using assignment_wt2_oauth;
using Elasticsearch.Net;
using Microsoft.Extensions.DependencyInjection;
using Nest;

var connectionSettings = new ConnectionSettings(new Uri("https://localhost:9200"));
connectionSettings.DisableDirectStreaming();
connectionSettings.BasicAuthentication("elastic", "hdNwhwXn6HF0-6KAh6EB");
connectionSettings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);

var elasticClient = new ElasticClient(connectionSettings);

var serviceProvider = new ServiceCollection()
    .AddSingleton<IUhrScraper, UhrScraper>()
    .AddSingleton<AddToElastic>()
    .AddSingleton<IElasticClient>(elasticClient)
    .BuildServiceProvider();

var UhrScraper = serviceProvider.GetService<IUhrScraper>();
var addToElastic = serviceProvider.GetService<AddToElastic>();

var data = await UhrScraper.GetData();

await addToElastic.AddData(data);