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
    public class OtherServiceNonTeachingStaffController : ControllerBase
    {
        private readonly Context _context;

        public OtherServiceNonTeachingStaffController(Context context)
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
        // GET: api/OtherServiceNonTeachingStaff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherServiceNonTeachingStaff>>> GetOtherServiceNonTeachingStaff()
        {
            if (_context.OtherServiceNonTeachingStaff == null)
            {
                return NotFound();
            }
            return await _context.OtherServiceNonTeachingStaff.ToListAsync();
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
        /// GET: api/OtherServiceNonTeachingStaff/5
        /// </example>
        // GET: api/OtherServiceNonTeachingStaff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OtherServiceNonTeachingStaff>> GetOtherServiceNonTeachingStaff(int id)
        {
            if (_context.OtherServiceNonTeachingStaff == null)
            {
                return NotFound();
            }
            var otherServiceNonTeachingStaff = await _context.OtherServiceNonTeachingStaff.FindAsync(id);

            if (otherServiceNonTeachingStaff == null)
            {
                return NotFound();
            }

            return otherServiceNonTeachingStaff;
        }

        /// <summary>
        /// this method updates a specific other service non teaching staff model.
        /// </summary>
        /// <param name="id">the id of the other service non teaching staff model.</param>
        /// <returns>a specific other service non teaching staff model.</returns>
        /// <response code="200">returns a specific other service non teaching staff model.</response>
        /// <response code="404">if the other service non teaching staff model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// PUT: api/OtherServiceNonTeachingStaff/5
        /// </example>
        /// 
        // PUT: api/OtherServiceNonTeachingStaff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtherServiceNonTeachingStaff(int id, OtherServiceNonTeachingStaff otherServiceNonTeachingStaff)
        {
            if (id != otherServiceNonTeachingStaff.Id)
            {
                return BadRequest();
            }

            _context.Entry(otherServiceNonTeachingStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherServiceNonTeachingStaffExists(id))
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
        ///  this method creates a new other service non teaching staff model.
        /// </summary>
        /// <param name="otherServiceNonTeachingStaff">the other service non teaching staff model.</param>
        /// <returns> the other service non teaching staff model created.</returns>
        /// <response code="201">returns the other service non teaching staff model created.</response>
        /// <response code="400">if the other service non teaching staff model is not found.</response>
        /// <response code="404">if the other service non teaching staff model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        // POST: api/OtherServiceNonTeachingStaff
        /// </example>
        /// 
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OtherServiceNonTeachingStaff>> PostOtherServiceNonTeachingStaff(OtherServiceNonTeachingStaff otherServiceNonTeachingStaff)
        {
            if (_context.OtherServiceNonTeachingStaff == null)
            {
                return Problem("Entity set 'Context.OtherServiceNonTeachingStaff'  is null.");
            }
            _context.OtherServiceNonTeachingStaff.Add(otherServiceNonTeachingStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtherServiceNonTeachingStaff", new { id = otherServiceNonTeachingStaff.Id }, otherServiceNonTeachingStaff);
        }

        // DELETE: api/OtherServiceNonTeachingStaff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOtherServiceNonTeachingStaff(int id)
        {
            if (_context.OtherServiceNonTeachingStaff == null)
            {
                return NotFound();
            }
            var otherServiceNonTeachingStaff = await _context.OtherServiceNonTeachingStaff.FindAsync(id);
            if (otherServiceNonTeachingStaff == null)
            {
                return NotFound();
            }

            _context.OtherServiceNonTeachingStaff.Remove(otherServiceNonTeachingStaff);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// this method gets the other service non teaching staff model by the parameters.
        /// </summary>
        /// <param name="parameters">the parameters of the other service non teaching staff model.</param>
        /// <returns>the other service non teaching staff model by the parameters.</returns> 
        private bool OtherServiceNonTeachingStaffExists(int id)
        {
            return (_context.OtherServiceNonTeachingStaff?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
