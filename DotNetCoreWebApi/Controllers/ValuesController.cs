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

        // GET values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var postDto = new Dto.Post
            {
                BlogId = 1,
                Content = "Test content modified last time",
                Title = "Test title modified",
                CreatedAt = DateTime.Now,
                Id = id
            };

            var resp = _postBusiness.Edit(postDto);

            return Ok(resp);
        }
    }
}
