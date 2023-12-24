using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.parameters.Expenses.Fixed;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the other expense model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetOtherExpenseModel, PutOtherExpenseModel, PostOtherExpenseModel, DeleteOtherExpenseModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OtherExpenseController : ControllerBase
    {
        private readonly Context _context;

        public OtherExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the other expense models.
        /// </summary>
        /// <returns>all the other expense models.</returns>
        /// <response code="200">returns all the other expense models.</response>
        /// <response code="404">if the other expense models are not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// GET: api/OtherExpense
        /// </example>

        // GET: api/OtherExpense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OtherExpenseModel>>> GetOtherExpenseModel()
        {
            if (_context.OtherExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.OtherExpenseModel.ToListAsync();
        }

        /// <summary>
        /// this method gets a specific other expense model.
        /// </summary>
        /// <param name="id">the id of the other expense model.</param>
        /// <returns>a specific other expense model.</returns>
        /// <response code="200">returns a specific other expense model.</response>
        /// <response code="404">if the other expense model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// GET: api/OtherExpense/5
        /// </example>

        // GET: api/OtherExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OtherExpenseModel>> GetOtherExpenseModel(int id)
        {
            if (_context.OtherExpenseModel == null)
            {
                return NotFound();
            }
            var otherExpenseModel = await _context.OtherExpenseModel.FindAsync(id);

            if (otherExpenseModel == null)
            {
                return NotFound();
            }

            return otherExpenseModel;
        }

        /// <summary>
        /// this method updates a specific other expense model.
        /// </summary>
        /// <param name="id">the id of the other expense model.</param>
        /// <param name="otherExpenseModel">the other expense model.</param>
        /// <returns> expence model updated.</returns>
        /// <response code="204">returns the updated other expense model.</response>
        /// <response code="400">if the other expense model is not found.</response>
        /// <response code="404">if the other expense model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// PUT: api/OtherExpense/5
        /// </example>

        // PUT: api/OtherExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtherExpenseModel(int id, OtherExpenseModel otherExpenseModel)
        {
            if (id != otherExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(otherExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherExpenseModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(otherExpenseModel);
        }

        /// <summary>
        /// this method creates a new other expense model.
        /// </summary>
        /// <param name="otherExpenseModel">the other expense model.</param>
        /// <returns>the other expense model created.</returns>
        /// <response code="201">returns the other expense model created.</response>
        /// <response code="400">if the other expense model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// POST: api/OtherExpense
        /// </example>

        // POST: api/OtherExpense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OtherExpenseModel>> PostOtherExpenseModel(OtherExpenseModel otherExpenseModel)
        {
            if (_context.OtherExpenseModel == null)
            {
                return Problem("Entity set 'Context.OtherExpenseModel'  is null.");
            }
            _context.OtherExpenseModel.Add(otherExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtherExpenseModel", new { id = otherExpenseModel.Id }, otherExpenseModel);
        }

        /// <summary>
        /// this method deletes a specific other expense model.
        /// </summary>
        /// <param name="id">the id of the other expense model.</param>
        /// <returns>the other expense model deleted.</returns>
        /// <response code="204">returns the other expense model deleted.</response>
        /// <response code="404">if the other expense model is not found.</response>
        /// <response code="500">if there is an internal server error.</response>
        /// <example>
        /// DELETE: api/OtherExpense/5
        /// </example>

        // DELETE: api/OtherExpense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOtherExpenseModel(int id)
        {
            if (_context.OtherExpenseModel == null)
            {
                return NotFound();
            }
            var otherExpenseModel = await _context.OtherExpenseModel.FindAsync(id);
            if (otherExpenseModel == null)
            {
                return NotFound();
            }

            _context.OtherExpenseModel.Remove(otherExpenseModel);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        /// <summary>
        /// this method checks if a specific other expense model exists.
        /// </summary>
        /// <param name="id">the id of the other expense model.</param>
        /// <returns>true if the other expense model exists or false if it doesn't.</returns>

        private bool OtherExpenseModelExists(int id)
        {
            return (_context.OtherExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
