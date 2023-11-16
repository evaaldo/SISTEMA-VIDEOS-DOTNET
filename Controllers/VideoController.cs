using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVideos.Context;
using SistemaVideos.Model;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            if(_context.Videos == null)
            {
                return NotFound();
            }

            return await _context.Videos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideos(int id)
        {
            if(_context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.FindAsync(id);

            if(video == null)
            {
                return NotFound();
            }

            return video;
        }

        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(Video video)
        {
            if(_context.Videos == null)
            {
                return Problem("O construtor do usuário é nulo");
            }

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideos", new { id = video.ID }, video);
        }
        
    }
}