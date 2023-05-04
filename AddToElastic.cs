/// <summary>
/// This code defines a class AddToElastic that allows to add data to an ElasticSearch index.
/// <summary>
using Nest;

namespace assignment_wt2_oauth
{
  public class AddToElastic
    {
    private readonly IElasticClient elasticClient;/// <summary>
        /// AddToElastic constructor takes an IElasticClient instance and sets it to a private variable.
        /// </summary>
        /// <param name="elasticClient"></param>
        public AddToElastic(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        /// <summary>
        /// AddData method allows to add an IEnumerable of Data to an ElasticSearch index and sends the data to ElasticSearch in batches.
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public async Task AddData(IEnumerable<Data> datas)
        {
            var index = "imdbdata";
            var batchSize = 200;
            var shipped = 0;

            while (datas.Skip(shipped).Take(batchSize).Any())
            {
                var batch = datas.Skip(shipped).Take(batchSize);
                var response = await elasticClient.BulkAsync(b => b.CreateMany(batch).Index(index));
                shipped += batchSize;
            }
        }
    }
}