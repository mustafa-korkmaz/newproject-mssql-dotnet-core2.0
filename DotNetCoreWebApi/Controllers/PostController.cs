using System;
using Business.Post;
using Common;
using Common.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.ApiObjects.Request.Post;
using WebApi.ApiObjects.ViewModels.Values;

namespace WebApi.Controllers
{
    [Route("post")]
    public class PostController : ApiBaseController
    {
        private readonly IPostBusiness _postBusiness;

        public PostController(IPostBusiness postBusiness)
        {
            _postBusiness = postBusiness;
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

        // GET post/all
        [HttpGet("all")]
        public IActionResult All()
        {
            var resp = GetPosts();

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        // edit post/add
        [HttpPost("add")]
        public IActionResult Add([FromBody] NewPostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = AddPost(request);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        // edit post/edit/5
        [HttpPost("{id}/edit")]
        public IActionResult Edit([FromRoute]int id, [FromBody] EditPostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = EditPost(id, request);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        private ApiResponse<PostViewModel> GetPost(int id)
        {
            var apiResp = new ApiResponse<PostViewModel>
            {
                ResponseCode = ResponseCode.Fail
            };

            var resp = _postBusiness.Get(id);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = resp.ResponseMessage;

                return apiResp;
            }

            apiResp.ResponseData = new PostViewModel
            {
                BlogId = resp.ResponseData.BlogId,
                Content = resp.ResponseData.Content,
                CreatedAt = resp.ResponseData.CreatedAt,
                Title = resp.ResponseData.Title
            };

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }

        private ApiResponse<IEnumerable<PostViewModel>> GetPosts()
        {
            var apiResp = new ApiResponse<IEnumerable<PostViewModel>>
            {
                ResponseCode = ResponseCode.Fail
            };

            var resp = _postBusiness.GetAll();

            if (resp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = resp.ResponseMessage;

                return apiResp;
            }

            apiResp.ResponseData = resp.ResponseData.Select(p => new PostViewModel
            {
                Id = p.Id,
                BlogId = p.BlogId,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                Title = p.Title
            });

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }

        private ApiResponse AddPost(NewPostRequest request)
        {
            var apiResp = new ApiResponse
            {
                ResponseCode = ResponseCode.Fail
            };

            var postDto = new Dto.Post
            {
                BlogId = request.BlogId,
                Content = request.Content,
                Title = request.Title,
                CreatedAt = DateTime.Now
            };

            _postBusiness.Add(postDto);

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }

        private ApiResponse EditPost(int id, EditPostRequest request)
        {
            var apiResp = new ApiResponse
            {
                ResponseCode = ResponseCode.Fail
            };

            var postDto = new Dto.Post
            {
                BlogId = request.BlogId,
                Content = request.Content,
                Title = request.Title,
                Id = id
            };

            var resp = _postBusiness.Edit(postDto);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = resp.ResponseMessage;

                return apiResp;
            }

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }
    }
}

