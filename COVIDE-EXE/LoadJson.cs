using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace COVID_19
{
    public class LoadJson
    {
        private string _jsonRegioneCache;
        private string _jsonNazioneCache;

        public LoadJson()
        {
            CacheData();
        }

        public IEnumerable<DataModel> GetData()
        {
            return JsonConvert.DeserializeObject<DataModel[]>(File.ReadAllText("COVID-19/dati-json/dpc-covid19-ita-regioni.json"));
        }

        public void CacheData()
        {
            _jsonRegioneCache = new WebClient().DownloadString("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni.json");
            _jsonNazioneCache = new WebClient().DownloadString("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-andamento-nazionale.json");

        }

        public IEnumerable<DataModel> GetDataFromWebRegione()
        {
            return JsonConvert.DeserializeObject<DataModel[]>(_jsonRegioneCache);
        }
        public IEnumerable<DataModel> GetDataFromWebNaz()
        {
            return JsonConvert.DeserializeObject<DataModel[]>(_jsonNazioneCache);
        }
    }
}
