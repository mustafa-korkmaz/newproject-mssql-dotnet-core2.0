using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
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

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        public class Test
        {
            public string MyProp1 { get; set; }
            public string MyProp2 { get; set; }
            public string MyProp3 { get; set; }
        }

       
    }
}
