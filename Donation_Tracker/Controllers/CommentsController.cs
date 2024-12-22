using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Donation_Tracker.Controllers
{
    public class CommentsController : ApiController
    {
        [HttpPost]
        [Route("api/comment/create")]
        public HttpResponseMessage Create(CommentDTO emp)
        {
            try
            {
                var data = CommentsService.Create(emp);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Auth.Logged]
        [HttpPost]
        [Route("api/comment/update")]
        public HttpResponseMessage Update(CommentDTO emp)
        {
            try
            {
                var data = CommentsService.Update(emp);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Auth.Logged]
        [HttpGet]
        [Route("api/comment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = CommentsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
