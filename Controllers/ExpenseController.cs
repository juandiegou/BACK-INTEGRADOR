using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters.Expenses;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the expense model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetExpenseModel, PutExpenseModel, PostExpenseModel, DeleteExpenseModel.
    /// </remarks>
    /// <example>
    /// GET: api/Expense
    /// </example>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly Context _context;

        public ExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the expenses.
        /// </summary>
        /// <returns>all the expenses</returns>
        /// <response code="200">returns all the expenses</response>
        /// <response code="404">if the expenses are null</response>
        /// <response code="500">if the expenses are null</response>
        /// <example>
        /// GET: api/Expense
        /// </example>
        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseModel>>> GetExpenseModel()
        {
            if (_context.ExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.ExpenseModel.ToListAsync();
        }

        /// <summary>
        /// this method gets an expense by id.
        /// </summary>
        /// <param name="id">the id of the expense</param>
        /// <returns>an expense by id</returns>
        /// <response code="200">returns an expense by id</response>
        /// <response code="404">if the expense is null</response>
        /// <response code="500">if the expense is null</response>
        /// <example>
        /// GET: api/Expense/5
        /// </example>

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseModel>> GetExpenseModel(int id)
        {
            if (_context.ExpenseModel == null)
            {
                return NotFound();
            }
            var expenseModel = await _context.ExpenseModel.FindAsync(id);

            if (expenseModel == null)
            {
                return NotFound();
            }

            return expenseModel;
        }

        /// <summary>
        /// this method updates an expense.
        /// </summary>
        /// <param name="id">
        /// the id of the expense</param>
        /// <param name="expenseModel"> the expense model that will be updated </param>
        /// <returns> an updated expense</returns>
        /// <response code="204">returns an updated expense</response>
        /// <response code="400">if the id of the expense is not equal to the id of the expense model</response>
        /// <response code="404">if the expense is null</response>
        /// <response code="500">if the expense is null</response>
        /// <example>
        /// PUT: api/Expense/5
        /// </example>

        // PUT: api/Expense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseModel(int id, ExpenseModel expenseModel)
        {
            if (id != expenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseModelExists(id))
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
        /// this method creates an expense.
        /// </summary>
        /// <param name="expenseModel"> the expense model that will be created </param>
        /// <returns> a created expense</returns>
        /// <response code="201">returns a created expense</response>
        /// <response code="400">if the expense is null</response>
        /// <response code="500">if the expense is null</response>
        /// <example>
        /// POST: api/Expense
        /// </example>

        // POST: api/Expense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> PostExpenseModel(ExpenseModel expenseModel)
        {
            if (_context.ExpenseModel == null)
            {
                return Problem("Entity set 'Context.ExpenseModel'  is null.");
            }
            _context.ExpenseModel.Add(expenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseModel", new { id = expenseModel.Id }, expenseModel);
        }

        /// <summary>
        /// this method deletes an expense.
        /// </summary>
        /// <param name="id">the id of the expense</param>
        /// <returns> a deleted expense</returns>
        /// <response code="204">returns a deleted expense</response>
        /// <response code="404">if the expense is null</response>
        /// <response code="500">if the expense is null</response>
        /// <example>
        /// DELETE: api/Expense/5
        /// </example>

        // DELETE: api/Expense/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseModel(int id)
        {
            if (_context.ExpenseModel == null)
            {
                return NotFound();
            }
            var expenseModel = await _context.ExpenseModel.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            _context.ExpenseModel.Remove(expenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method checks if an expense exists.
        /// </summary>
        /// <param name="id">the id of the expense</param>
        /// <returns> a boolean value</returns>


        private bool ExpenseModelExists(int id)
        {
            return (_context.ExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
