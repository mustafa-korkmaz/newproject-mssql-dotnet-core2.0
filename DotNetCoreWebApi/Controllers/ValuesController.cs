using Business.Post;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var postDto = new Dto.Post
            {
                BlogId = 1,
                Content = "Test content",
                Title = "Test title",
                CreatedAt=DateTime.Now
            };

            _postBusiness.Add(postDto);

            _postBusiness.Delete(id);

            return Ok(postDto);
        }
    }
}
