using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlogWeb.Controllers
{

    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger) 
        {
            _logger = logger;
        }

        [Route("values/index")]
        public IActionResult Index()
        {
            try
            {
                int i = 0;
                int res = 1 / i;
            }
            catch (Exception ex)
            {
                throw ex;      
            }
            return Ok();
        }
        /// <summary>
        /// <![CDATA[测试]]>
        /// </summary>
        /// <returns></returns>
        [Route("values/test")]
        public IActionResult Test() 
        {
            _logger.LogError("git修改");
            int i = 0;
            int res = 1 / i;
            return Ok();
        }
    }
}
