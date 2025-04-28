using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {


        private readonly VideoGameDbContext _context;

        public VideoGameController(VideoGameDbContext context)
        {
            _context = context;
        }

        // Get all the list
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        //// Get games by id
        [HttpGet("{id}")]

        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }
        //// add new game
        [HttpPost]

        public async Task< ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame == null)
                return BadRequest();

            // This is to add data to the DB, it only begin to track not save
           _context.VideoGames.Add(newGame);

            //The save chamges async save data on the DB
            await _context.SaveChangesAsync();  

            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);

        }

        ////edit game
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
                return NotFound();

            game.Title = updatedGame.Title;
            game.Publisher = updatedGame.Publisher;
            game.Developer = updatedGame.Developer;
            game.Platform = updatedGame.Platform;


            await _context.SaveChangesAsync();
            return NoContent();

        }

        //// delete game
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteVideoGame(int id)
        {

            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();  
            return NoContent();
        }


    }



}
