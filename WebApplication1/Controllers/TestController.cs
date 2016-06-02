using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Services;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [System.Web.Http.RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        public IEnumerable<string> Get() => _testService.GetTestValues();
    }
}
