using backend.Domain.Dto;
using backend.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace backend.Service.Extensions
{
    public static class ControllerExtension {
        public static string ReadJwnToken(this Controller controller) {
            var authHeader = controller.HttpContext.Request.Headers.First(h => h.Key == "Authorization");
            return authHeader.Value.First().Replace("Bearer ", "");
        }
    }
}
