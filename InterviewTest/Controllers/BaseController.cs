using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InterviewTest.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public ObjectResult SendResponse<T>(T response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ObjectResult(response) { StatusCode = (int)statusCode };
        }
    }
}
