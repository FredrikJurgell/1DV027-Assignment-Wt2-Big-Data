using System.Globalization;
using System.Text.Json.Serialization;
using CsvHelper;

namespace assignment_wt2_oauth
{
  public class ImdbData : IImdbData
    {
        public async Task<IEnumerable<Data>> GetData()
        {
            var imdbData = new List<Data>();
            using (var reader = new StreamReader("imdb_top_1000.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                await csv.ReadAsync();
                csv.ReadHeader();
                while (await csv.ReadAsync())
                {
                    var record = csv.GetRecord<Data>();
                    imdbData.Add(record);
                }
            }
            return imdbData;
        }
    }

    public class Data
    {
        [JsonPropertyName("Poster_Link")]
        public string Poster_Link { get; set; }

        [JsonPropertyName("Series_Title")]
        public object Series_Title { get; set; }

        [JsonPropertyName("Released_Year")]
        public object Released_Year { get; set; }

        [JsonPropertyName("Certificate")]
        public object Certificate { get; set; }

        [JsonPropertyName("Runtime")]
        public string Runtime { get; set; }

        [JsonPropertyName("Genre")]
        public string Genre { get; set; }

        [JsonPropertyName("IMDB_Rating")]
        public double IMDB_Rating { get; set; }

        [JsonPropertyName("Overview")]
        public string Overview { get; set; }

        [JsonPropertyName("Meta_score")]
        public object Meta_score { get; set; }

        [JsonPropertyName("Director")]
        public string Director { get; set; }

        [JsonPropertyName("Star1")]
        public string Star1 { get; set; }

        [JsonPropertyName("Star2")]
        public string Star2 { get; set; }

        [JsonPropertyName("Star3")]
        public string Star3 { get; set; }

        [JsonPropertyName("Star4")]
        public string Star4 { get; set; }

        [JsonPropertyName("No_of_Votes")]
        public int No_of_Votes { get; set; }

        [JsonPropertyName("Gross")]
        public string Gross { get; set; }
    }
}
