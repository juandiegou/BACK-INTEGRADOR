using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the leader model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetLeaderModel, PutLeaderModel, PostLeaderModel, DeleteLeaderModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LeaderController : ControllerBase
    {
        private readonly Context _context;

        public LeaderController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method returns all the leaders.
        /// </summary>
        /// <returns>all the leaders</returns>
        /// <response code="200">returns all the leaders</response>
        /// <response code="404">if there are no leaders</response>
        /// <response code="500">if the entity set 'Context.LeaderModel' is null</response>
        /// <example>
        /// GET: api/Leader
        /// </example>
        /// <remarks>
        /// This method returns all the leaders.
        /// </remarks>

        // GET: api/Leader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaderModel>>> GetLeaderModel()
        {
            if (_context.LeaderModel == null)
            {
                return NotFound();
            }
            return await _context.LeaderModel.ToListAsync();
        }

        /// <summary>
        /// this method gets a leader by id.
        /// </summary>
        /// <returns>a leader</returns>
        /// <response code="200">returns a leader</response>
        /// <response code="404">if the leader is null</response>
        /// <response code="500">if the entity set 'Context.LeaderModel' is null</response>
        /// <example>
        /// GET: api/Leader/5
        /// </example>
        /// <remarks>
        /// This method gets a leader by id.
        /// </remarks>

        // GET: api/Leader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaderModel>> GetLeaderModel(int id)
        {
            if (_context.LeaderModel == null)
            {
                return NotFound();
            }
            var leaderModel = await _context.LeaderModel.FindAsync(id);

            if (leaderModel == null)
            {
                return NotFound();
            }

            return leaderModel;
        }

        /// <summary>
        /// this method updates a leader.
        /// </summary>
        /// <param name="id">the id of the leader</param>
        /// <param name="leaderModel">the leader</param>
        /// <returns>an updated leader</returns>
        /// <response code="204">returns an updated leader</response>
        /// <response code="400">if the id of the leader is different from the id of the updated leader</response>
        /// <response code="404">if the leader is null</response>
        /// <response code="500">if the entity set 'Context.LeaderModel' is null</response>
        /// <example>
        /// PUT: api/Leader/5
        /// </example>
        /// <remarks>
        /// This method updates a leader.
        /// </remarks>


        // PUT: api/Leader/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaderModel(int id, LeaderModel leaderModel)
        {
            if (id != leaderModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(leaderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaderModelExists(id))
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

        /// <summary>
        /// this method creates a leader.
        /// </summary>
        /// <param name="leaderModel">the leader</param>
        /// <returns>a created leader</returns>
        /// <response code="201">returns a created leader</response>
        /// <response code="500">if the entity set 'Context.LeaderModel' is null</response>
        /// <example>
        /// POST: api/Leader
        /// </example>
        /// <remarks>
        /// This method creates a leader.
        /// </remarks>
        // POST: api/Leader
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeaderModel>> PostLeaderModel(LeaderModel leaderModel)
        {
            if (_context.LeaderModel == null)
            {
                return Problem("Entity set 'Context.LeaderModel'  is null.");
            }
            _context.LeaderModel.Add(leaderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaderModel", new { id = leaderModel.Id }, leaderModel);
        }

        /// <summary>
        /// this method deletes a leader.
        /// </summary>
        /// <param name="id">the id of the leader</param>
        /// <returns>a deleted leader</returns>
        /// <response code="204">returns a deleted leader</response>
        /// <response code="404">if the leader is null</response>
        /// <response code="500">if the entity set 'Context.LeaderModel' is null</response>
        /// <example>
        /// DELETE: api/Leader/5
        /// </example>
        /// <remarks>
        /// This method deletes a leader.
        /// </remarks>
        // DELETE: api/Leader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaderModel(int id)
        {
            if (_context.LeaderModel == null)
            {
                return NotFound();
            }
            var leaderModel = await _context.LeaderModel.FindAsync(id);
            if (leaderModel == null)
            {
                return NotFound();
            }

            _context.LeaderModel.Remove(leaderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method gets the leaders of a specific project.
        /// </summary>
        /// <param name="projectId">the id of the project</param>
        /// <returns>the leaders exist or not</returns>
        private bool LeaderModelExists(int id)
        {
            return (_context.LeaderModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
