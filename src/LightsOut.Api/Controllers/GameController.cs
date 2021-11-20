using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightsOut.Api.Data;
using LightsOut.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LightsOut.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var gameSettings = await _context.GameSettings.FindAsync(id);

            if (gameSettings == null)
            {
                return NotFound();
            }

            var rng = new Random();
            Game game = new Game();
            game.InitialSate = new List<int>();
            for(int i = 0; i < gameSettings.BoardSize * gameSettings.BoardSize; i++)
            {
                game.InitialSate.Add(rng.Next(0, 2));
            }

            return game;
        }
    }
}
