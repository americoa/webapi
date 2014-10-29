using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAspWebApi.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public Dictionary<string, string> Test()
        {
            Dictionary<string, string> _test = new Dictionary<string, string>();
            _test.Add("01", "TEST");
            return _test;
        }
    }
}
