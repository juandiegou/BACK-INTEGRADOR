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
    /// this class represents the controller of the teacher model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetTeacherModel, PutTeacherModel, PostTeacherModel, DeleteTeacherModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly Context _context;

        public TeacherController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the teacher model.
        /// </summary>
        /// <returns>
        /// the teacher model list.
        /// </returns>
        /// <response code="200">Returns the teacher model list.</response>
        /// <response code="404">If the teacher model list is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        /// <example>
        /// GET: api/Teacher
        /// </example>

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherModel>>> GetTeacherModel()
        {
            if (_context.TeacherModel == null)
            {
                return NotFound();
            }
            return await _context.TeacherModel.
            Include(t => t.Leader)
            .ToListAsync();
        }

        /// <summary>
        /// this method gets the teacher model by id.
        /// </summary>
        /// <returns>
        /// the teacher model.
        /// </returns>
        /// <response code="200">Returns the teacher model.</response>
        /// <response code="404">If the teacher model is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        /// <example>
        /// GET: api/Teacher/5
        /// </example>
        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherModel>> GetTeacherModel(int id)
        {
            if (_context.TeacherModel == null)
            {
                return NotFound();
            }
            var teacherModel = await _context.TeacherModel
                .Include(t => t.Leader)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (teacherModel == null)
            {
                return NotFound();
            }

            return teacherModel;
        }

        /// <summary>
        /// this method gets the teacher model by name.
        /// </summary>
        /// <returns>
        /// the teacher model which has the same id.
        /// </returns>
        /// <response code="200">Returns the teacher model.</response>
        /// <response code="404">If the teacher model is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        /// <example>
        // PUT: api/Teacher/5
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherModel(int id, TeacherModel teacherModel)
        {
            if (id != teacherModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherModelExists(id))
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
        /// this method creates a new teacher model.
        /// </summary>
        /// <returns>
        /// the teacher model.
        /// </returns>
        /// <response code="200">Returns the teacher model.</response>
        /// <response code="404">If the teacher model is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        /// <example>
        // POST: api/Teacher
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherModel>> PostTeacherModel(TeacherModel teacherModel)
        {
            if (_context.TeacherModel == null)
            {
                return Problem("Entity set 'Context.TeacherModel'  is null.");
            }
            _context.TeacherModel.Add(teacherModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherModel", new { id = teacherModel.Id }, teacherModel);
        }

        /// <summary>
        /// this method deletes the teacher model by id.
        /// </summary>
        /// <returns>
        /// the teacher model.
        /// </returns>
        /// <response code="200">Returns the teacher model.</response>
        /// <response code="404">If the teacher model is null.</response>
        /// <response code="500">If there is an internal server error.</response>
        /// <example>
        // DELETE: api/Teacher/5
        /// </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherModel(int id)
        {
            if (_context.TeacherModel == null)
            {
                return NotFound();
            }
            var teacherModel = await _context.TeacherModel.FindAsync(id);
            if (teacherModel == null)
            {
                return NotFound();
            }

            _context.TeacherModel.Remove(teacherModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method gets a boolean value if the teacher model exists.
        /// </summary>
        /// <returns>
        /// if the teacher model exists.
        /// </returns>

        private bool TeacherModelExists(int id)
        {
            return (_context.TeacherModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
