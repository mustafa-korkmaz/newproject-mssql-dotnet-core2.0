using Common;
using Common.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Business.Blog;
using WebApi.ApiObjects.ViewModels.Blog;

namespace WebApi.Controllers
{
    [Route("blog")]
    public class BlogController : ApiBaseController
    {
        private readonly IBlogBusiness _blogBusiness;

        public BlogController(IBlogBusiness blogBusiness)
        {
            _blogBusiness = blogBusiness;
        }

        // GET post/all
        [HttpGet("all")]
        public IActionResult All()
        {
            var resp = GetBlogs();

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        // GET post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resp = GetPost(id);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        private ApiResponse<IEnumerable<BlogViewModel>> GetBlogs()
        {
            var apiResp = new ApiResponse<IEnumerable<BlogViewModel>>
            {
                ResponseCode = ResponseCode.Fail
            };

            var resp = _blogBusiness.SearchBlogs("google.com");

            apiResp.ResponseData = resp.Select(p => new BlogViewModel
            {
                Id = p.Id,
                Url = p.Url
            });

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }

        private ApiResponse<BlogViewModel> GetPost(int id)
        {
            var apiResp = new ApiResponse<BlogViewModel>
            {
                ResponseCode = ResponseCode.Fail
            };

            var resp = _blogBusiness.Get(id);

            apiResp.ResponseData = new BlogViewModel
            {
                Id = resp.Id,
                Url = resp.Url
            };

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }
    }
}

