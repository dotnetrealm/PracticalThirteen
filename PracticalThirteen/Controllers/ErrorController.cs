﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticalThirteen.Models;
using System.Diagnostics;

namespace PracticalThirteen.Controllers
{
    public class ErrorController : Controller
    {
        readonly IDictionary<int, string> statusMessages = new Dictionary<int, string>();
        public ErrorController()
        {
            statusMessages.Add(401, "User identity was not found!");
            statusMessages.Add(403, "You don't have permission to access this resources!");
            statusMessages.Add(404, "Sorry, the page you are looking for could not be found.");
            statusMessages.Add(500, "Whoops, something went wrong on our servers!");
            statusMessages.Add(503, "Service unavailable!");
        }

        /// <summary>
        /// Exception/Error page handling
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error/{statusCode?}")]
        public IActionResult Error(int statusCode)
        {
            var errorFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            string message = String.Empty;
            if (errorFeature == null)
            {
                // Prepare message for Exception
                var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
                message = exceptionFeature?.Error.Message ?? statusMessages[500];
            }
            else
            {
                // Prepare message for Error page
                message = (statusMessages.ContainsKey(statusCode)) ? statusMessages[statusCode] : "Something went wrong!";
            }

            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode,
                Message = message,
                OriginalPath = errorFeature?.OriginalPath ?? string.Empty,
            });
        }
    }
}
