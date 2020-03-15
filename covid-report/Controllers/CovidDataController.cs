using System;
using System.Collections.Generic;
using System.Linq;
using COVID_19;
using Microsoft.AspNetCore.Mvc;

namespace covid_report.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidDataController : ControllerBase
    {
        [HttpGet("positivi")]
        public IEnumerable<int> GetPositivi(string regione)
        {
            return new LoadJson().GetDataFromWeb().Where(x => x.Regione.ToUpperInvariant().Contains(regione.ToUpperInvariant())).OrderBy(x=>x.Data).Select(x=>x.Positivi).ToArray();
        }

        [HttpGet("deceduti")]
        public IEnumerable<int> GetDeceduti(string regione)
        {
            return new LoadJson().GetDataFromWeb().Where(x => x.Regione.ToUpperInvariant().Contains(regione.ToUpperInvariant())).OrderBy(x => x.Data).Select(x => x.Deceduti).ToArray();
        }

        [HttpGet("date")]
        public IEnumerable<string> GetDate(string regione)
        {
            return new LoadJson().GetDataFromWeb().Where(x => x.Regione.ToUpperInvariant().Contains(regione.ToUpperInvariant())).OrderBy(x => x.Data).Select(x => x.Data.ToShortDateString()).ToArray();
        }
    }
}
