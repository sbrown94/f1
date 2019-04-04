using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;
using System.Web.Http;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Routing;
using System.Net;
using Newtonsoft.Json;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace F1Server.Controllers
{
    public class RaceController : ApiController
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        [Route("api/v1/Race/GetCurrentRace")]
        public IHttpActionResult GetCurrentRace()
        {
            return GetData("CurrentRace");
        }

        [Route("api/v1/Race/GetDriverStandings")]
        public IHttpActionResult GetDriverStandings()
        {
            return GetData("DriverStandings");
        }

        [Route("api/v1/Race/GetConstructorStandings")]
        public IHttpActionResult GetConstructorStandings()
        {
            return GetData("ConstructorStandings");
        }

        public IHttpActionResult GetData(string key)
        {
            string cacheKey = key;
            if (_cache.Contains(cacheKey))
            {
                return Ok(_cache.Get(cacheKey));
            }

            string requestUrl = "null";

            switch(key)
            {
                case "CurrentRace": requestUrl = "https://ergast.com/api/f1/current/next.json";
                    break;
                case "DriverStandings": requestUrl = "http://ergast.com/api/f1/current/driverStandings.json";
                    break;
                default:
                    break;
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUrl).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request failed. Server replied: " + response.Content.ReadAsStringAsync().Result);
                }

                object tmpRes = null;

                switch (key)
                {
                    case "CurrentRace": tmpRes = JsonConvert.DeserializeObject<RaceData.RaceData>(response.Content.ReadAsStringAsync().Result);
                        break;
                    case "DriverStandings": tmpRes = JsonConvert.DeserializeObject<DriverStandings.DriverStandings>(response.Content.ReadAsStringAsync().Result);
                        break;
                    default:
                        tmpRes = null;
                        break;
                }

                var result = tmpRes;
                _cache.Add(cacheKey, result, DateTime.Now.AddMinutes(120));
                return Ok(result);
            }
        }
    }
}