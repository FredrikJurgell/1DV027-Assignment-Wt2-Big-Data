using System;
using System.Text.Json.Serialization;
using RestSharp;

namespace assignment_wt2_oauth
{
    public class UhrScraper : IUhrScraper
    {
        public async Task<IEnumerable<Data>> GetData()
        {
            var start = "HT";
            var startYear = 10;

            var endYear = int.Parse(DateTime.Now.ToString("yy"));

            var restClient = new RestClient("https://www.uhr.se/");

            var data = new List<Data>();

            for (var a = startYear; endYear > a; a++)
            {
                var request = new RestRequest("/api/antagningsstatistik/searchTotal");
                request.AddQueryParameter("searchfor", " ");
                request.AddQueryParameter("searchterm", start + a.ToString());
                request.AddQueryParameter("pagesize", 1000);
                request.AddQueryParameter("page", 1);
                request.AddQueryParameter("tillfalle", "urv2");
                request.AddQueryParameter("larosaten", "LNU");
                request.AddQueryParameter("utbildningstyp", "program");

                var response = await restClient.ExecuteGetAsync<Root>(request);
                var timeStamp = new DateTime(2000 + a, 9, 1);
                response.Data.data.ForEach(x => x.Timestamp = timeStamp);

                data.AddRange(response.Data.data);
            }

            return data;
        }
    }

    public class Data
    {
        [JsonPropertyName("senasteUrval")]
        public string senasteUrval { get; set; }

        [JsonPropertyName("uppkomsttillfälleHeader")]
        public string uppkomsttillflleHeader { get; set; }

        [JsonPropertyName("tillfälleId")]
        public object tillflleId { get; set; }

        [JsonPropertyName("tillfälle")]
        public object tillflle { get; set; }

        [JsonPropertyName("terminId")]
        public string terminId { get; set; }

        [JsonPropertyName("termin")]
        public string termin { get; set; }

        [JsonPropertyName("år")]
        public object r { get; set; }

        [JsonPropertyName("antagningsomgångId")]
        public string antagningsomgngId { get; set; }

        [JsonPropertyName("antagningsomgångKategori")]
        public string antagningsomgngKategori { get; set; }

        [JsonPropertyName("lärosäteId")]
        public string lrosteId { get; set; }

        [JsonPropertyName("lärosäte")]
        public string lroste { get; set; }

        [JsonPropertyName("anmälningsalternativId")]
        public string anmlningsalternativId { get; set; }

        [JsonPropertyName("anmälningskod")]
        public string anmlningskod { get; set; }

        [JsonPropertyName("anmälningsalternativ")]
        public string anmlningsalternativ { get; set; }

        [JsonPropertyName("anmälningsalternativEngelska")]
        public string anmlningsalternativEngelska { get; set; }

        [JsonPropertyName("utbildningstyp")]
        public string utbildningstyp { get; set; }

        [JsonPropertyName("utbildningId")]
        public string utbildningId { get; set; }

        [JsonPropertyName("utbildningsnyckel")]
        public string utbildningsnyckel { get; set; }

        [JsonPropertyName("inställd")]
        public string instlld { get; set; }

        [JsonPropertyName("kursId")]
        public object kursId { get; set; }

        [JsonPropertyName("programId")]
        public string programId { get; set; }

        [JsonPropertyName("programinriktning")]
        public string programinriktning { get; set; }

        [JsonPropertyName("studietakt")]
        public string studietakt { get; set; }

        [JsonPropertyName("startperiod")]
        public string startperiod { get; set; }

        [JsonPropertyName("undervisningsform")]
        public string undervisningsform { get; set; }

        [JsonPropertyName("studietid")]
        public string studietid { get; set; }

        [JsonPropertyName("studieort")]
        public string studieort { get; set; }

        [JsonPropertyName("examen")]
        public string examen { get; set; }

        [JsonPropertyName("ämnesgrupp")]
        public object mnesgrupp { get; set; }

        [JsonPropertyName("nyckelord")]
        public object nyckelord { get; set; }

        [JsonPropertyName("sok")]
        public Sok sok { get; set; }

        [JsonPropertyName("urval1")]
        public Urval1 urval1 { get; set; }

        [JsonPropertyName("urval2")]
        public Urval2 urval2 { get; set; }
    public DateTime Timestamp { get; internal set; }
  }

    public class Root
    {
        [JsonPropertyName("antalObjekt")]
        public int antalObjekt { get; set; }

        [JsonPropertyName("data")]
        public List<Data> data { get; set; }
    }

    public class Sok
    {
        [JsonPropertyName("sökande")]
        public int skande { get; set; }

        [JsonPropertyName("förstahandsökande")]
        public int frstahandskande { get; set; }

        [JsonPropertyName("kvinnligaSökande")]
        public int kvinnligaSkande { get; set; }

        [JsonPropertyName("manligaSökande")]
        public int manligaSkande { get; set; }

        [JsonPropertyName("kvinnligaFörstahandsökande")]
        public int kvinnligaFrstahandskande { get; set; }

        [JsonPropertyName("manligaFörstahandsökande")]
        public int manligaFrstahandskande { get; set; }

        [JsonPropertyName("sökande24ÅrEllerYngre")]
        public int skande24rEllerYngre { get; set; }

        [JsonPropertyName("sökande25Till34År")]
        public int skande25Till34r { get; set; }

        [JsonPropertyName("sökande35ÅrEllerÄldre")]
        public int skande35rEllerldre { get; set; }

        [JsonPropertyName("förstahandsökande24ÅrEllerYngre")]
        public int frstahandskande24rEllerYngre { get; set; }

        [JsonPropertyName("förstahandsökande25Till34År")]
        public int frstahandskande25Till34r { get; set; }

        [JsonPropertyName("förstahandsökande35ÅrEllerÄldre")]
        public int frstahandskande35rEllerldre { get; set; }
    }

    public class Urval1
    {
        [JsonPropertyName("urvalsgrupper")]
        public List<Urvalsgrupper> urvalsgrupper { get; set; }

        [JsonPropertyName("antagna")]
        public int antagna { get; set; }

        [JsonPropertyName("reserver")]
        public int reserver { get; set; }

        [JsonPropertyName("kvinnligaAntagna")]
        public int kvinnligaAntagna { get; set; }

        [JsonPropertyName("manligaAntagna")]
        public int manligaAntagna { get; set; }

        [JsonPropertyName("kvinnligaReserver")]
        public int kvinnligaReserver { get; set; }

        [JsonPropertyName("manligaReserver")]
        public int manligaReserver { get; set; }

        [JsonPropertyName("antagna24ÅrEllerYngre")]
        public int antagna24rEllerYngre { get; set; }

        [JsonPropertyName("antagna25Till34År")]
        public int antagna25Till34r { get; set; }

        [JsonPropertyName("antagna35ÅrEllerÄldre")]
        public int antagna35rEllerldre { get; set; }

        [JsonPropertyName("reserver24ÅrEllerYngre")]
        public int reserver24rEllerYngre { get; set; }

        [JsonPropertyName("reserver25Till34År")]
        public int reserver25Till34r { get; set; }

        [JsonPropertyName("reserver35ÅrEllerÄldre")]
        public int reserver35rEllerldre { get; set; }
    }

    public class Urval2
    {
        [JsonPropertyName("urvalsgrupper")]
        public List<Urvalsgrupper> urvalsgrupper { get; set; }

        [JsonPropertyName("antagna")]
        public int antagna { get; set; }

        [JsonPropertyName("reserver")]
        public int reserver { get; set; }

        [JsonPropertyName("kvinnligaAntagna")]
        public int kvinnligaAntagna { get; set; }

        [JsonPropertyName("manligaAntagna")]
        public int manligaAntagna { get; set; }

        [JsonPropertyName("kvinnligaReserver")]
        public int kvinnligaReserver { get; set; }

        [JsonPropertyName("manligaReserver")]
        public int manligaReserver { get; set; }

        [JsonPropertyName("antagna24ÅrEllerYngre")]
        public int antagna24rEllerYngre { get; set; }

        [JsonPropertyName("antagna25Till34År")]
        public int antagna25Till34r { get; set; }

        [JsonPropertyName("antagna35ÅrEllerÄldre")]
        public int antagna35rEllerldre { get; set; }

        [JsonPropertyName("reserver24ÅrEllerYngre")]
        public int reserver24rEllerYngre { get; set; }

        [JsonPropertyName("reserver25Till34År")]
        public int reserver25Till34r { get; set; }

        [JsonPropertyName("reserver35ÅrEllerÄldre")]
        public int reserver35rEllerldre { get; set; }
    }

    public class Urvalsgrupper
    {
        [JsonPropertyName("urvalsgruppId")]
        public string urvalsgruppId { get; set; }

        [JsonPropertyName("lägstaAntagnaPoäng")]
        public string lgstaAntagnaPong { get; set; }

        [JsonPropertyName("antagna")]
        public int antagna { get; set; }

        [JsonPropertyName("reserver")]
        public int reserver { get; set; }
    }
}
