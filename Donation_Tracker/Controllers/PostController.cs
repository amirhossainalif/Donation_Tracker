using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace Donation_Tracker.Controllers
{
    public class PostController : ApiController
    {
        [Auth.Logged]
        [HttpGet]
        [Route("api/posts")]
        public HttpResponseMessage Posts()
        {
            try
            {
                var data = PostService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [Auth.Logged]
        [HttpGet]
        [Route("api/posts/{id}")]
        public HttpResponseMessage Posts(int id)
        {
            try
            {
                var data = PostService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [Auth.Logged]
        [HttpGet]
        [Route("api/posts/{id}/comments")]
        public HttpResponseMessage PostComments(int id)
        {
            try
            {
                var data = PostService.GetwithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [Auth.Logged]
        [HttpPost]
        [Route("api/post/create")]
        public HttpResponseMessage Create(PostDTO emp)
        {
            try
            {
                var data = PostService.Create(emp);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Auth.Logged]
        [HttpPost]
        [Route("api/post/update")]
        public HttpResponseMessage Update(PostDTO emp)
        {
            try
            {
                var data = PostService.Update(emp);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Auth.Logged]
        [HttpGet]
        [Route("api/post/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PostService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
