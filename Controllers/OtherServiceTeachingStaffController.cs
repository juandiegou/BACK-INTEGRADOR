using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters.Expenses.Services;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the other service non teaching staff model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetOtherServiceNonTeachingStaff, PutOtherServiceNonTeachingStaff, PostOtherServiceNonTeachingStaff, DeleteOtherServiceNonTeachingStaff.
    /// </remarks>
    /// 
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OtherServiceTeachingStaffController : ControllerBase
    {
        private readonly Context _context;

        public OtherServiceTeachingStaffController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the other service non teaching staff models.
        /// </summary>
        /// <returns>all the other service non teaching staff models.</returns>
        /// <response code="200">returns all the other service non teaching staff models.</response>
        /// <response code="404">if the other service non teaching staff models are not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// GET: api/OtherServiceNonTeachingStaff
        /// </example>
        /// 

        // GET: api/OtherServiceTeachingStaff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherServiceTeachingStaff>>> GetOtherServiceTeachingStaff()
        {
            if (_context.OtherServiceTeachingStaff == null)
            {
                return NotFound();
            }
            return await _context.OtherServiceTeachingStaff.ToListAsync();
        }

        /// <summary>
        /// this method gets a specific other service non teaching staff model.
        /// </summary>
        /// <param name="id">the id of the other service non teaching staff model.</param>
        /// <returns>a specific other service non teaching staff model.</returns>
        /// <response code="200">returns a specific other service non teaching staff model.</response>
        /// <response code="404">if the other service non teaching staff model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// GET: api/OtherServiceTeachingStaff/5
        /// </example>
        /// 

        // GET: api/OtherServiceTeachingStaff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OtherServiceTeachingStaff>> GetOtherServiceTeachingStaff(int id)
        {
            if (_context.OtherServiceTeachingStaff == null)
            {
                return NotFound();
            }
            var otherServiceTeachingStaff = await _context.OtherServiceTeachingStaff.FindAsync(id);

            if (otherServiceTeachingStaff == null)
            {
                return NotFound();
            }

            return otherServiceTeachingStaff;
        }

        /// <summary>
        /// this method updates a specific other service non teaching staff model.
        /// </summary>
        /// <param name="id">the id of the other service non teaching staff model.</param>
        /// <param name="otherServiceTeachingStaff">other service non teaching staff model object.</param>
        /// <returns> other service non teaching staff model updated .</returns>
        /// <response code="204">returns no content.</response>
        /// <response code="400">if the id of the other service non teaching staff model is not the same as the id of the object.</response>
        /// <response code="404">if the other service non teaching staff model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// PUT: api/OtherServiceTeachingStaff/5
        /// </example>
        // PUT: api/OtherServiceTeachingStaff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtherServiceTeachingStaff(int id, OtherServiceTeachingStaff otherServiceTeachingStaff)
        {
            if (id != otherServiceTeachingStaff.Id)
            {
                return BadRequest();
            }

            _context.Entry(otherServiceTeachingStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherServiceTeachingStaffExists(id))
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
        /// this method creates a new other service non teaching staff model.
        /// </summary>
        /// <param name="otherServiceTeachingStaff">other service non teaching staff model object.</param>
        /// <returns> the new other service non teaching staff model created .</returns>
        /// <response code="201">returns the new other service non teaching staff model created.</response>
        /// <response code="400">if the other service non teaching staff model is null.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// POST: api/OtherServiceTeachingStaff
        /// </example>
        // POST: api/OtherServiceTeachingStaff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OtherServiceTeachingStaff>> PostOtherServiceTeachingStaff(OtherServiceTeachingStaff otherServiceTeachingStaff)
        {
            if (_context.OtherServiceTeachingStaff == null)
            {
                return Problem("Entity set 'Context.OtherServiceTeachingStaff'  is null.");
            }
            _context.OtherServiceTeachingStaff.Add(otherServiceTeachingStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtherServiceTeachingStaff", new { id = otherServiceTeachingStaff.Id }, otherServiceTeachingStaff);
        }

        /// <summary>
        /// this method deletes a specific other service non teaching staff model.
        /// </summary>
        /// <param name="id">the id of the other service non teaching staff model.</param>
        /// <returns> the other service non teaching staff model deleted .</returns>
        /// <response code="204">returns no content.</response>
        /// <response code="404">if the other service non teaching staff model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        // DELETE: api/OtherServiceTeachingStaff/5
        /// </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOtherServiceTeachingStaff(int id)
        {
            if (_context.OtherServiceTeachingStaff == null)
            {
                return NotFound();
            }
            var otherServiceTeachingStaff = await _context.OtherServiceTeachingStaff.FindAsync(id);
            if (otherServiceTeachingStaff == null)
            {
                return NotFound();
            }

            _context.OtherServiceTeachingStaff.Remove(otherServiceTeachingStaff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method gets the other service non teaching staff model by the parameters.
        /// </summary>
        /// <param name="parameters">the parameters of the other service non teaching staff model.</param>
        /// <returns> the other service non teaching staff model by the parameters.</returns>

        private bool OtherServiceTeachingStaffExists(int id)
        {
            return (_context.OtherServiceTeachingStaff?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
