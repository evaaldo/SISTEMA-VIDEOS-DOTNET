using Microsoft.AspNetCore.Mvc;
using SistemaVideos.Context;

namespace SistemaVideos.Controller
{
    [Route("Videos")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly VideoContext? _context;

        public VideoController(VideoContext context)
        {
            _context = context;
        }
    }
}