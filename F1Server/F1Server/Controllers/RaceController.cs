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
using System.Net;
using Newtonsoft.Json;

namespace F1Server.Controllers
{
    public class RaceController : ApiController
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        public IHttpActionResult GetCurrentRace()
        {
            string cacheKey = "CurrentRace";
            if(_cache.Contains(cacheKey)) {
                return Ok(_cache.Get(cacheKey));
            }


            string requestUrl = "https://ergast.com/api/f1/current/next.json";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUrl).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request failed. Server replied: " + response.Content.ReadAsStringAsync().Result);
                }
                var result = JsonConvert.DeserializeObject<RaceData>(response.Content.ReadAsStringAsync().Result);
                _cache.Add(cacheKey, result, DateTime.Now.AddMinutes(120));
                return Ok(result);
            }
        }
    }
}