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
    /// this class represents the controller of the fixed expense model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetFixedExpenseModel, PutFixedExpenseModel, PostFixedExpenseModel, DeleteFixedExpenseModel.
    /// </remarks>
    /// <example>
    /// GET: api/FixedExpense
    /// 
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FixedExpenseController : ControllerBase
    {
        private readonly Context _context;

        public FixedExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the fixed expenses.
        /// </summary>
        /// <returns>all the fixed expenses</returns>
        /// <response code="200">returns all the fixed expenses</response>
        /// <response code="404">if the fixed expenses are null</response>
        /// <response code="500">if the entity set 'Context.FixedExpenseModel' is null</response>
        /// <example>
        /// GET: api/FixedExpense
        /// </example>
        /// <remarks>
        /// This method returns all the fixed expenses.
        /// </remarks>

        // GET: api/FixedExpense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixedExpenseModel>>> GetFixedExpenseModel()
        {
            if (_context.FixedExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.FixedExpenseModel.ToListAsync();
        }

        /// <summary>
        /// this method gets a fixed expense by id.
        /// </summary>
        /// <param name="id">the id of the fixed expense</param>
        /// <returns>a fixed expense</returns>
        /// <response code="200">returns a fixed expense by id</response>
        /// <response code="404">if the fixed expense is null</response>
        /// <response code="500">if the entity set 'Context.FixedExpenseModel' is null</response>
        /// <example>
        /// GET: api/FixedExpense/5
        /// </example>
        /// <remarks>
        /// This method returns a fixed expense by id.
        /// </remarks>
        // GET: api/FixedExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FixedExpenseModel>> GetFixedExpenseModel(int id)
        {
            if (_context.FixedExpenseModel == null)
            {
                return NotFound();
            }
            var fixedExpenseModel = await _context.FixedExpenseModel.FindAsync(id);

            if (fixedExpenseModel == null)
            {
                return NotFound();
            }

            return fixedExpenseModel;
        }

        /// <summary>
        /// this method updates a fixed expense.
        /// </summary>
        /// <param name="id"> the id of the fixed expense</param>
        /// <param name="fixedExpenseModel">< the fixed expense to update </param>
        /// <returns>  the updated fixed expense </returns>
        /// <response code="200">returns the updated fixed expense</response>
        /// <response code="400">if the id of the fixed expense is different from the id of the fixed expense to update</response>
        /// <response code="404">if the fixed expense is null</response>
        /// <response code="500">if the entity set 'Context.FixedExpenseModel' is null</response>
        /// <example>
        /// PUT: api/FixedExpense/5
        /// </example>
        /// <remarks>
        /// This method updates a fixed expense.
        /// </remarks>

        // PUT: api/FixedExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFixedExpenseModel(int id, FixedExpenseModel fixedExpenseModel)
        {
            if (id != fixedExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(fixedExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixedExpenseModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(fixedExpenseModel);
        }

        /// <summary>
        /// this method creates a fixed expense.
        /// </summary>
        /// <param name="fixedExpenseModel"> the fixed expense to create </param>
        /// <returns> the created fixed expense </returns>
        /// <response code="201">returns the created fixed expense</response>
        /// <response code="500">if the entity set 'Context.FixedExpenseModel' is null</response>
        /// <example>
        /// POST: api/FixedExpense
        /// </example>
        /// <remarks>
        /// This method creates a fixed expense.
        /// </remarks>

        // POST: api/FixedExpense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FixedExpenseModel>> PostFixedExpenseModel(FixedExpenseModel fixedExpenseModel)
        {
            if (_context.FixedExpenseModel == null)
            {
                return Problem("Entity set 'Context.FixedExpenseModel'  is null.");
            }
            _context.FixedExpenseModel.Add(fixedExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFixedExpenseModel", new { id = fixedExpenseModel.Id }, fixedExpenseModel);
        }

        // DELETE: api/FixedExpense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFixedExpenseModel(int id)
        {
            if (_context.FixedExpenseModel == null)
            {
                return NotFound();
            }
            var fixedExpenseModel = await _context.FixedExpenseModel.FindAsync(id);
            if (fixedExpenseModel == null)
            {
                return NotFound();
            }

            _context.FixedExpenseModel.Remove(fixedExpenseModel);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        /// <summary>
        /// this method checks if a fixed expense exists.
        /// </summary>
        /// <param name="id"> the id of the fixed expense </param>
        /// <returns> a boolean </returns>

        private bool FixedExpenseModelExists(int id)
        {
            return (_context.FixedExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
