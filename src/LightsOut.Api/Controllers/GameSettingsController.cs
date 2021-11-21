using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LightsOut.Api.Data;
using LightsOut.Api.Models;

namespace LightsOut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSettingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameSettings>>> GetGameSettings()
        {
            return await _context.GameSettings.ToListAsync();
        }

        // GET: api/GameSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameSettings>> GetGameSettings(int id)
        {
            var gameSettings = await _context.GameSettings.FindAsync(id);

            if (gameSettings == null)
            {
                return NotFound();
            }

            #region generate initial state of game
            var rng = new Random();
            gameSettings.InitialState = new List<List<int>>();
            for (int i = 0; i < gameSettings.BoardSize; i++)
            {
                List<int> list = new List<int>();

                for(int j = 0; j < gameSettings.BoardSize; j++)
                {
                    list.Add(rng.Next(0, 2));
                }

                gameSettings.InitialState.Add(list);
            }
            #endregion

            return gameSettings;
        }

        // PUT: api/GameSettings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameSettings(int id, GameSettings gameSettings)
        {
            if (id != gameSettings.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameSettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameSettingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameSettings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameSettings>> PostGameSettings(GameSettings gameSettings)
        {
            _context.GameSettings.Add(gameSettings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameSettings", new { id = gameSettings.Id }, gameSettings);
        }

        // DELETE: api/GameSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameSettings>> DeleteGameSettings(int id)
        {
            var gameSettings = await _context.GameSettings.FindAsync(id);
            if (gameSettings == null)
            {
                return NotFound();
            }

            _context.GameSettings.Remove(gameSettings);
            await _context.SaveChangesAsync();

            return gameSettings;
        }

        private bool GameSettingsExists(int id)
        {
            return _context.GameSettings.Any(e => e.Id == id);
        }
    }
}
