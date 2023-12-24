using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters.Expenses.Special;

namespace API.Controllers
{
    /// <summary>
    /// a controller for the special expense model.
    /// </summary>
    /// <remarks>
    /// This controller allows to Create, Read, Update and Delete special expenses.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SpecialExpenseController : ControllerBase
    {
        private readonly Context _context;

        public SpecialExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all special expenses.
        /// </summary>
        /// <returns> a list of special expenses.</returns>
        /// <response code="200">Returns the list of special expenses.</response>
        /// <response code="404">If the list of special expenses is null.</response>
        /// <response code="500">If there is a server error.</response>
        /// <example> 
        // GET: api/SpecialExpense
        /// </example>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialExpenseModel>>> GetSpecialExpenseModel()
        {
            if (_context.SpecialExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.SpecialExpenseModel.ToListAsync();
        }

        /// <summary>
        /// this method allows to get a special expense by id.
        /// </summary>
        /// <param name="id">the id of the special expense.</param>
        /// <returns> a special expense.</returns>
        /// <response code="200">Returns the special expense.</response>
        /// <response code="404">If the special expense is null.</response>
        /// <response code="500">If there is a server error.</response>
        /// <example> 
        // GET: api/SpecialExpense/5
        /// </example>
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialExpenseModel>> GetSpecialExpenseModel(int id)
        {
            if (_context.SpecialExpenseModel == null)
            {
                return NotFound();
            }
            var specialExpenseModel = await _context.SpecialExpenseModel.FindAsync(id);

            if (specialExpenseModel == null)
            {
                return NotFound();
            }

            return specialExpenseModel;
        }

        /// <summary>
        /// this method allows to update a special expense.
        /// </summary>
        /// <param name="id">the id of the special expense.</param>
        /// <param name="specialExpenseModel">the special expense to update.</param>
        /// <returns> a updated special expense.</returns> 
        /// <response code="200">Returns the updated special expense.</response>
        /// <response code="400">If the id of the special expense is different from the id of the special expense to update.</response>
        /// <response code="404">If the special expense is null.</response>
        /// <response code="500">If there is a server error.</response>
        /// <example>
        // PUT: api/SpecialExpense/5
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialExpenseModel(int id, SpecialExpenseModel specialExpenseModel)
        {
            if (id != specialExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialExpenseModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(specialExpenseModel);
        }

        /// <summary>
        /// this method allows to create a special expense.
        /// </summary>
        /// <param name="specialExpenseModel">the special expense to create.</param>
        /// <returns> a created special expense.</returns> 
        /// <response code="200">Returns the created special expense.</response>
        /// <response code="400">If the special expense is null.</response>
        /// <response code="500">If there is a server error.</response>
        /// <example>
        // POST: api/SpecialExpense
        //</example>

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecialExpenseModel>> PostSpecialExpenseModel(SpecialExpenseModel specialExpenseModel)
        {
            if (_context.SpecialExpenseModel == null)
            {
                return Problem("Entity set 'Context.SpecialExpenseModel'  is null.");
            }
            _context.SpecialExpenseModel.Add(specialExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialExpenseModel", new { id = specialExpenseModel.Id }, specialExpenseModel);
        }

        /// <summary>
        /// this method allows to delete a special expense.
        /// </summary>
        /// <param name="id">the id of the special expense.</param>
        /// <returns> a deleted special expense.</returns> 
        /// <response code="200">Returns the deleted special expense.</response>
        /// <response code="404">If the special expense is null.</response>
        /// <response code="500">If there is a server error.</response>
        /// <example>
        // DELETE: api/SpecialExpense/5
        // </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialExpenseModel(int id)
        {
            if (_context.SpecialExpenseModel == null)
            {
                return NotFound();
            }
            var specialExpenseModel = await _context.SpecialExpenseModel.FindAsync(id);
            if (specialExpenseModel == null)
            {
                return NotFound();
            }

            _context.SpecialExpenseModel.Remove(specialExpenseModel);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        /// <summary>
        /// thi method allows to get a special expense by parameters.
        /// </summary>
        /// <param name="id">the id of the special expense.</param>
        /// <returns>if the special expense exists.</returns>
        private bool SpecialExpenseModelExists(int id)
        {
            return (_context.SpecialExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
