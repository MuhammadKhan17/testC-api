using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticapi.Models;

namespace ticapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameDetailsController : ControllerBase
    {
        private readonly GameDetailsContext _context;

        public GameDetailsController(GameDetailsContext context)
        {
            _context = context;
        }

        // GET: api/GameDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDetails>>> GetGameDetails()
        {
            return await _context.Games
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/GameDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDetails>> Getgame(long id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return ItemToDTO(game);
        }
        // PUT: api/GameDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Updategame(long id, GameDetails gameDTO)
        {
            if (id != gameDTO.Id)
            {
                return BadRequest();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            game.Id = gameDTO.Id;
            game.Players = gameDTO.Players;
            game.Player1Moves = gameDTO.Player1Moves;
            game.Player2Moves = gameDTO.Player2Moves;
            game.board=gameDTO.board;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!gameExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> MakeTurn(long id, GameDetails gameDTO)
        {
            if (id != gameDTO.Id)
            {
                return BadRequest();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            game.Player1Moves = game.Player1Moves+gameDTO.Player1Moves;
            game.Player2Moves = game.Player1Moves+gameDTO.Player2Moves;
            game.position=gameDTO.position;
            char[] temp=gameDTO.board.ToCharArray();
            temp[gameDTO.position]='T';
            game.board=temp.ToString();
            game.turn=gameDTO.turn;

            if(game.board.Substring(0,4).Equals("T,T,T")
            ||game.board.Substring(5,9).Equals("T,T,T")
            ||game.board.Substring(10,14).Equals("T,T,T")){
                Console.WriteLine("Game Over. Player:{0} wins",game.turn);
            }
            else if(game.board.ElementAt(0).Equals("T")
            &&game.board.ElementAt(7).Equals("T")
            &&game.board.ElementAt(14).Equals("T")){
                Console.WriteLine("Game Over. Player:{0} wins",game.turn);
            }else if(game.board.ElementAt(4).Equals("T")
            &&game.board.ElementAt(7).Equals("T")
            &&game.board.ElementAt(10).Equals("T")){
                Console.WriteLine("Game Over. Player:{0} wins",game.turn);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!gameExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    //post -h Content-Type=application/json -c "{"Players":"test3, test4","Player1Moves":"","Player2Moves":"","board":"F,F,F,F,F,F,F,F,F"}"
        // POST: api/GameDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        
        [HttpPost]
        public async Task<ActionResult<GameDetails>> Creategame(GameDetails gameDTO)
        {
            var game = new GameDetails
            {
                Players = gameDTO.Players,
                Player1Moves = gameDTO.Player1Moves,
                Player2Moves = gameDTO.Player2Moves,
                board=gameDTO.board  
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Getgame),
                new { id = game.Id },
                ItemToDTO(game));
        }

        // DELETE: api/GameDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegame(long id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool gameExists(long id)
        {
            return _context.Games.Any(e => e.Id == id);
        }

        private static GameDetails ItemToDTO(GameDetails game) =>
            new GameDetails
            {
                Id = game.Id,
                Players = game.Players,
                Player1Moves = game.Player1Moves,
                Player2Moves = game.Player2Moves,
                board=game.board  
            };
    }
}