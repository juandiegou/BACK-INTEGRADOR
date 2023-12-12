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
    /// this is the controller for the Subject entity
    /// </summary>
    /// <remarks>
    /// This controller contains all the methods to interact with the Subject entity
    /// </remarks>

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [Produces("application/json")]
    public class SubjectController : ControllerBase
    {
        private readonly Context _context;

        public SubjectController(Context context)
        {
            _context = context;
        }


        /// <sumary>
        /// Get all the subjects in the database
        /// </sumary>
        /// <returns>
        /// A list of subjects
        /// </returns>
        /// <response code="200">Returns the list of subjects</response>
        /// <response code="404">If the list of subjects is null</response>
        /// <response code="500">If there is a problem with the database</response>
        /// <example>
        /// GET: api/Subject
        /// </example>

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> GetSubjectModel()
        {
            if (_context.SubjectModel == null)
            {
                return NotFound();
            }
            return await _context.SubjectModel
            .Include(s => s.Teacher)
            .ToListAsync();
        }

        /// <sumary>
        /// Get a specific subject in the database
        /// </sumary>
        /// <returns>
        /// A subject with the id passed in the parameters
        /// </returns>
        /// <response code="200">Returns the subject</response>
        /// <response code="404">If the subject is null</response>
        /// <response code="500">If there is a problem with the database</response>
        /// <example>
        /// GET: api/Subject/5
        /// </example>

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectModel>> GetSubjectModel(int id)
        {
            if (_context.SubjectModel == null)
            {
                return NotFound();
            }
            var subjectModel = await _context.SubjectModel
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subjectModel == null)
            {
                return NotFound();
            }

            return subjectModel;
        }

        /// <sumary>
        /// Get a specific subject in the database
        /// </sumary>
        /// <returns>
        /// A updated subject with the id passed in the parameters
        /// </returns>
        /// <response code="200">Returns the updated subject</response>
        /// <response code="404">If the subject is null</response>
        /// <response code="500">If there is a problem with the database</response>
        /// <example>
        /// PUT: api/Subject/5
        /// </example>

        // PUT: api/Subject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectModel(int id, SubjectModel subjectModel)
        {
            if (id != subjectModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectModelExists(id))
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


        /// <sumary>
        /// Create a specific subject in the database
        /// </sumary>
        /// <returns>
        /// A created subject
        /// </returns>
        /// <response code="200">Returns the created subject</response>
        /// <response code="404">If the subject is null</response>
        /// <response code="500">If there is a problem with the database</response>
        /// <example>
        /// POST: api/Subject
        /// </example>
        // POST: api/Subject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectModel>> PostSubjectModel(SubjectModel subjectModel)
        {
            if (_context.SubjectModel == null)
            {
                return Problem("Entity set 'Context.SubjectModel'  is null.");
            }
            _context.SubjectModel.Add(subjectModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectModel", new { id = subjectModel.Id }, subjectModel);
        }

        /// <sumary>
        /// Delete a specific subject in the database
        /// </sumary>
        /// <returns>
        /// No Content
        /// </returns>
        /// <response code="200">Returns No Content</response>
        /// <response code="404">If the subject is null</response>
        /// <response code="500">If there is a problem with the database</response>
        /// <example>
        /// DELETE: api/Subject/5
        /// </example>

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectModel(int id)
        {
            if (_context.SubjectModel == null)
            {
                return NotFound();
            }
            var subjectModel = await _context.SubjectModel.FindAsync(id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            _context.SubjectModel.Remove(subjectModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check if a subject exists in the databasethis me
        /// </summary>
        /// <param name="id">The id of the subject</param> 
        /// <returns>True if the subject exists, false otherwise</returns>

        private bool SubjectModelExists(int id)
        {
            return (_context.SubjectModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
