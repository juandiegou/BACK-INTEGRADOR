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
    /// this class represents the controller of the general expense model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetGeneralExpenseModel, PutGeneralExpenseModel, PostGeneralExpenseModel, DeleteGeneralExpenseModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    ///[Authorize]
    public class GeneralExpenseController : ControllerBase
    {
        private readonly Context _context;

        public GeneralExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the general expenses.
        /// </summary>
        /// <returns>all the general expenses</returns>
        /// <response code="200">returns all the general expenses</response>
        /// <response code="404">if the general expenses are null</response>
        /// <response code="500">if the entity set 'Context.GeneralExpenseModel' is null</response>
        /// <example>
        /// GET: api/GeneralExpense
        /// </example>
        /// <remarks>
        /// This method returns all the general expenses.
        /// </remarks> 

        // GET: api/GeneralExpense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralExpenseModel>>> GetGeneralExpenseModel()
        {
            if (_context.GeneralExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.GeneralExpenseModel.ToListAsync();
        }

        // GET: api/GeneralExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralExpenseModel>> GetGeneralExpenseModel(int id)
        {
            if (_context.GeneralExpenseModel == null)
            {
                return NotFound();
            }
            var generalExpenseModel = await _context.GeneralExpenseModel.FindAsync(id);

            if (generalExpenseModel == null)
            {
                return NotFound();
            }

            return generalExpenseModel;
        }

        /// <summary>
        /// this method updates a general expense.
        /// </summary>
        /// <param name="id">the id of the general expense</param>
        /// <param name="generalExpenseModel">the general expense</param>
        /// <returns>an updated general expense</returns>
        /// <response code="204">returns an updated general expense</response>
        /// <response code="400">if the id of the general expense is different from the id of the updated general expense</response>
        /// <response code="404">if the general expense is null</response>
        /// <response code="500">if the entity set 'Context.GeneralExpenseModel' is null</response>
        /// <example>
        /// PUT: api/GeneralExpense/5
        /// </example>
        /// <remarks>
        /// This method updates a general expense.
        /// </remarks>
        // PUT: api/GeneralExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralExpenseModel(int id, GeneralExpenseModel generalExpenseModel)
        {
            if (id != generalExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralExpenseModelExists(id))
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
        /// this method creates a general expense.
        /// </summary>
        /// <param name="generalExpenseModel">the general expense to create</param>
        /// <returns>the created general expense</returns>
        /// <response code="201">returns the created general expense</response>
        /// <response code="400">if the general expense is null</response>
        /// <response code="500">if the entity set 'Context.GeneralExpenseModel' is null</response>
        /// <example>
        /// POST: api/GeneralExpense
        /// </example>
        /// <remarks>
        /// This method creates a general expense.
        /// </remarks>

        // POST: api/GeneralExpense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneralExpenseModel>> PostGeneralExpenseModel(GeneralExpenseModel generalExpenseModel)
        {
            if (_context.GeneralExpenseModel == null)
            {
                return Problem("Entity set 'Context.GeneralExpenseModel'  is null.");
            }
            _context.GeneralExpenseModel.Add(generalExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralExpenseModel", new { id = generalExpenseModel.Id }, generalExpenseModel);
        }

        /// <summary>
        /// this method deletes a general expense.
        /// </summary>
        /// <param name="id">the id of the general expense to delete</param>
        /// <returns>the deleted general expense</returns>
        /// <response code="204">returns the deleted general expense</response>
        /// <response code="404">if the general expense is null</response>
        /// <response code="500">if the entity set 'Context.GeneralExpenseModel' is null</response>
        /// <example>
        /// DELETE: api/GeneralExpense/5
        /// </example>
        /// <remarks>
        /// This method deletes a general expense.
        /// </remarks>

        // DELETE: api/GeneralExpense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralExpenseModel(int id)
        {
            if (_context.GeneralExpenseModel == null)
            {
                return NotFound();
            }
            var generalExpenseModel = await _context.GeneralExpenseModel.FindAsync(id);
            if (generalExpenseModel == null)
            {
                return NotFound();
            }

            _context.GeneralExpenseModel.Remove(generalExpenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method checks if a general expense exists.
        /// </summary>
        /// <param name="id"> the id of the general expense</param>
        /// <returns> a boolean value that indicates if the general expense exists</returns>


        private bool GeneralExpenseModelExists(int id)
        {
            return (_context.GeneralExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
