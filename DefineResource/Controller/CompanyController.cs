using Microsoft.AspNetCore.Mvc;

namespace DefineResource.Controller
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {

        static List<string> _names = new List<string>();

        static CompanyController()
        {
            _names.Add("mahesh");
            _names.Add("suresh");
            _names.Add("naresh");
        }

        [HttpGet]
        public IEnumerable<string> All()
        {
            return _names;
        }
    }
}
