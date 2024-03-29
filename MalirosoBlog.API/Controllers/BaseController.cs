﻿using MalirosoBlog.Models.Entities;
using MalirosoBlog.Services.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace MalirosoBlog.API.Controllers
{
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "User is forbidden", Type = typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "User is unauthorized", Type = typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        public BaseController()
        {

        }

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override OkObjectResult Ok(object value)
        {
            SuccessResponse response = new()
            {
                Data = value,
                Success = true
            };

            return base.Ok(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public new OkObjectResult Ok()
        {
            SuccessResponse response = new()
            {
                Success = true
            };

            return base.Ok(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public NotFoundObjectResult NotFound()
        {
            SuccessResponse response = new()
            {
                Success = false,
            };

            return base.NotFound(response);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public OkObjectResult Invalid()
        {
            SuccessResponse response = new()
            {

                Success = false
            };

            /*return invalid */
            return base.Ok(response);

        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<string> GetUserIdAsync()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            return user.Id;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetUserId()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public OkObjectResult Error()
        {
            SuccessResponse response = new()
            {
                Success = false
            };

            return base.Ok(response);
        }
    }
}
