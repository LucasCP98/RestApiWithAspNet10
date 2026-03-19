using Microsoft.AspNetCore.Mvc;
using RestApiWithAspNet10.Controllers.Model;

namespace RestApiWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        // O _conunter substitui o this.
        private static long _counter = 0;
        private static readonly string _template = "hello, {0}";

        [HttpGet]
        public Greeting Get([FromQuery] string name = "World")
        {
            var id = Interlocked.Increment(ref _counter);
            var content = string.Format(_template, name);
            return new Greeting(1, content);
        }
    }
}
