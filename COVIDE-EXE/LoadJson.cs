using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace COVID_19
{
    public class LoadJson
    {
        public IEnumerable<DataModel> GetData()
        {
            return JsonConvert.DeserializeObject<DataModel[]>(File.ReadAllText("COVID-19/dati-json/dpc-covid19-ita-regioni.json"));
        }

        public IEnumerable<DataModel> GetDataFromWeb()
        {
            var client = new WebClient();
            var resp = client.DownloadString("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni.json");
            return JsonConvert.DeserializeObject<DataModel[]>(resp);
        }
        public IEnumerable<DataModel> GetDataFromWebNaz()
        {
            var client = new WebClient();
            var resp = client.DownloadString("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-andamento-nazionale.json");
            return JsonConvert.DeserializeObject<DataModel[]>(resp);
        }
    }
}
