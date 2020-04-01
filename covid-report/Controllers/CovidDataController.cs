using System;
using System.Collections.Generic;
using System.Linq;
using COVID_19;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace covid_report.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidDataController : ControllerBase
    {
        private readonly LoadJson loadJson;

        public CovidDataController(LoadJson loadJson, IMemoryCache cache)
        {
            this.loadJson = loadJson;
            //var entryOptions = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Low);
        }

        [HttpGet("positivi")]
        public IEnumerable<int> GetPositivi(string regione)
        {
            if (regione.ToUpper().Contains("ITA"))
                return loadJson.GetDataFromWebNaz().OrderBy(x => x.Data).Select(x => x.VariazioneTotalePositivi).ToArray();
            return loadJson.GetDataFromWebRegione().Where(x => x.Regione.ToUpperInvariant().Contains(regione.ToUpperInvariant())).OrderBy(x => x.Data).Select(x => x.VariazioneTotalePositivi).ToArray();
        }

        [HttpGet("deceduti")]
        public IEnumerable<int> GetDeceduti(string regione)
        {

            if (regione.ToUpper().Contains("ITA"))
                return loadJson.GetDataFromWebNaz().OrderBy(x => x.Data).Select(x => x.Deceduti).ToArray();
            return loadJson.GetDataFromWebRegione().Where(x => x.Regione.ToUpperInvariant().Contains(regione.ToUpperInvariant())).OrderBy(x => x.Data).Select(x => x.Deceduti).ToArray();
        }

        [HttpGet("date")]
        public IEnumerable<string> GetDate(string regione)
        {

            if (regione.ToUpper().Contains("ITA"))
                return loadJson.GetDataFromWebNaz().OrderBy(x => x.Data).Select(x => x.Data.ToShortDateString()).ToArray();
            return loadJson.GetDataFromWebRegione().Where(x => x.Regione.ToUpperInvariant().Contains(regione.ToUpperInvariant())).OrderBy(x => x.Data).Select(x => x.Data.ToShortDateString()).ToArray();
        }

        [HttpGet("miglioramento")]
        public IEnumerable<DataModel> GetMiglioramento(string regione)
        {
            var miglioramenti = new List<DataModel>();
            var data = loadJson.GetDataFromWebRegione();
            foreach (var item in data)
            {
                var result = data.Where(x => 
                                            x.Regione == item.Regione && 
                                            x.Data == item.Data.AddDays(-1) && 
                                            x.NuoviPositivi < item.NuoviPositivi).Where(x=> x.NuoviPositivi != 0)
                    .FirstOrDefault();
                if (result != null) miglioramenti.Add(result);
            }
            return miglioramenti.OrderBy(x=> x.Regione).OrderBy(x=> x.Data).Where(x=> x.Regione.ToUpper().Contains(regione.ToUpper())).ToArray();
        }
    }
}
