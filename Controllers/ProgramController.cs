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
    /// this class represents the controller of the program model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetProgramModel, PutProgramModel, PostProgramModel, DeleteProgramModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProgramController : ControllerBase
    {
        private readonly Context _context;

        public ProgramController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the program model.
        /// </summary>
        /// <returns>the program model.</returns>
        /// <response code="200">returns the program model.</response>
        /// <response code="404">if the program model is null.</response>
        /// <response code="500">if the program model is null.</response>
        /// <example>
        /// GET: api/Program
        /// </example>
        // GET: api/Program
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramModel>>> GetProgramModel()
        {
            if (_context.ProgramModel == null)
            {
                return NotFound();
            }
            return await _context.ProgramModel.ToListAsync();
        }

        /// <summary>
        /// this method gets the program model by id.
        /// </summary>
        /// <param name="id">the id of the program model.</param>
        /// <returns>the program model.</returns>
        /// <response code="200">returns the program model.</response>
        /// <response code="404">if the program model is null.</response>
        /// <response code="500">if the program model is null.</response>
        /// <example>
        // GET: api/Program/5
        /// </example>

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramModel>> GetProgramModel(int id)
        {
            if (_context.ProgramModel == null)
            {
                return NotFound();
            }
            var programModel = await _context.ProgramModel.FindAsync(id);

            if (programModel == null)
            {
                return NotFound();
            }

            return programModel;
        }

        /// <summary>
        /// this method updates the program model.
        /// </summary>
        /// <param name="id">the id of the program model.</param>
        /// <param name="programModel">the program model.</param>
        /// <returns>the program model updated.</returns> 
        /// <response code="200">returns the program model updated.</response>
        /// <response code="400">if the program model is null.</response>
        /// <response code="404">if the program model is null.</response>
        /// <response code="500">if the program model is null.</response>
        /// <example>
        // PUT: api/Program/5
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramModel(int id, ProgramModel programModel)
        {
            if (id != programModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(programModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramModelExists(id))
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
        /// this method creates the program model.
        /// </summary>
        /// <param name="programModel">the program model.</param>
        /// <returns>the program model created.</returns>
        /// <response code="200">returns the program model created.</response>
        /// <response code="400">if the program model is null.</response>
        /// <response code="404">if the program model is null.</response>
        /// <response code="500">if the program model is null.</response>
        /// <example>
        // POST: api/Program
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramModel>> PostProgramModel(ProgramModel programModel)
        {
            if (_context.ProgramModel == null)
            {
                return Problem("Entity set 'Context.ProgramModel'  is null.");
            }
            _context.ProgramModel.Add(programModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramModel", new { id = programModel.Id }, programModel);
        }

        /// <summary>
        /// this method deletes the program model.
        /// </summary>
        /// <param name="id">the id of the program model.</param>
        /// <returns>the program model deleted.</returns>
        /// <response code="200">returns the program model deleted.</response>
        /// <response code="400">if the program model is null.</response>
        /// <response code="404">if the program model is null.</response>
        /// <response code="500">if the program model is null.</response>
        /// <example>
        // DELETE: api/Program/5
        /// </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramModel(int id)
        {
            if (_context.ProgramModel == null)
            {
                return NotFound();
            }
            var programModel = await _context.ProgramModel.FindAsync(id);
            if (programModel == null)
            {
                return NotFound();
            }

            _context.ProgramModel.Remove(programModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method gets the program model by name.
        ///  </summary>
        /// <param name="name">the name of the program model.</param>
        /// <returns> if the program model exists.</returns>
        private bool ProgramModelExists(int id)
        {
            return (_context.ProgramModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
