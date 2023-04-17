using System;
using Nest;

namespace assignment_wt2_oauth
{
    public class AddToElastic
    {
    private readonly IElasticClient elasticClient;

    public AddToElastic(IElasticClient elasticClient)
    {
        this.elasticClient = elasticClient;
    }

    public async Task AddData(IEnumerable<Data> datas){

            var index = "imdbdata";
            var batchSize = 200;
            var shiped = 0;

            while (datas.Skip(shiped).Take(batchSize).Any())
            {
                var batch = datas.Skip(shiped).Take(batchSize);
                var response = await elasticClient.BulkAsync(b => b.CreateMany(batch).Index(index));
                shiped += batchSize;
            }
        }
    }
}
