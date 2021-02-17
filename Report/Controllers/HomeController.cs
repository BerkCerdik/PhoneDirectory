using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Report.Model.ORM.Context;
using Newtonsoft.Json;
using Confluent.Kafka;

namespace Report.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ReportContext _reportContext;
        private ConsumerConfig _config;

        public HomeController(ReportContext reportcontext, ConsumerConfig config)
        {
            _reportContext = reportcontext;
            this._config = config;
        }
        
        [Route("getpeople")]
        [HttpGet]
        public IActionResult GetPeople()
        {
            using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
            {
                consumer.Subscribe("Berk");
                while (true)
                {
                    var cr = consumer.Consume();
                    var msg = cr.Message.Value;
                    return Ok(msg);
                }
            }
        }
    }
}
