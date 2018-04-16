using Business.Post;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("values")]
    public class ValuesController : ApiBaseController
    {
        private readonly IPostBusiness _postBusiness;

        public ValuesController(IPostBusiness postBusiness)
        {
            this._postBusiness = postBusiness;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var jsonConventionTest = new Test
            {
                MyProp1 = _postBusiness.GetContent(id),
                MyProp2 = "qwd"
            };

            return Ok(jsonConventionTest);
        }

        public class Test
        {
            public string MyProp1 { get; set; }
            public string MyProp2 { get; set; }
            public string MyProp3 { get; set; }
        }
       
    }
}
