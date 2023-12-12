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
    /// this class represents the controller of the investment expense model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetinvestmentExpenseModel, PutinvestmentExpenseModel, PostinvestmentExpenseModel, DeleteinvestmentExpenseModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InvestmentExpenseController : ControllerBase
    {
        private readonly Context _context;

        public InvestmentExpenseController(Context context)
        {
            _context = context;
        }


        /// <summary>
        /// this method gets all the investment expenses.
        /// </summary>
        /// <returns>all the investment expenses</returns>
        /// <response code="200">returns all the investment expenses</response>
        /// <response code="404">if there are no investment expenses</response>
        /// <response code="500">if the entity set 'Context.investmentExpenseModel' is null</response>
        /// <example>
        /// GET: api/InvestmentExpense
        /// </example>
        /// <remarks>
        /// This method returns all the investment expenses.
        /// </remarks>
        // GET: api/InvestmentExpense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestmentExpenseModel>>> GetInvestmentExpenseModel()
        {
            if (_context.InvestmentExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.InvestmentExpenseModel.ToListAsync();
        }

        /// <summary>
        /// this method gets a investment expense by id.
        /// </summary>
        /// <returns>a investment expense</returns>
        /// <response code="200">returns a investment expense</response>
        /// <response code="404">if the investment expense is null</response>
        /// <response code="500">if the entity set 'Context.investmentExpenseModel' is null</response>
        /// <example>
        /// GET: api/InvestmentExpense/5
        /// </example>
        /// <remarks>
        /// This method returns a investment expense by id.
        /// </remarks>

        // GET: api/InvestmentExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestmentExpenseModel>> GetInvestmentExpenseModel(int id)
        {
            if (_context.InvestmentExpenseModel == null)
            {
                return NotFound();
            }
            var investmentExpenseModel = await _context.InvestmentExpenseModel.FindAsync(id);

            if (investmentExpenseModel == null)
            {
                return NotFound();
            }

            return investmentExpenseModel;
        }

        /// <summary>
        /// this method updates a investment expense.
        /// </summary>
        /// <param name="id">the id of the investment expense</param>
        /// <param name="investmentExpenseModel">the investment expense</param>
        /// <returns> an updated investment expense</returns>
        /// <response code="204">returns no content</response>
        /// <response code="400">if the id of the investment expense is different from the id of the investment expense model</response>
        /// <response code="404">if the investment expense is null</response>
        /// <response code="500">if the entity set 'Context.investmentExpenseModel' is null</response>
        /// <example>
        /// PUT: api/InvestmentExpense/5
        /// </example>
        /// <remarks>
        /// This method updates a investment expense.
        /// </remarks>

        // PUT: api/InvestmentExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestmentExpenseModel(int id, InvestmentExpenseModel investmentExpenseModel)
        {
            if (id != investmentExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(investmentExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExpenseModelExists(id))
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
        /// this method creates a investment expense.
        /// </summary>
        /// <param name="investmentExpenseModel">the investment expense</param>
        /// <returns> a created investment expense</returns>
        /// <response code="201">returns a created investment expense</response>
        /// <response code="400">if the investment expense is null</response>
        /// <response code="500">if the entity set 'Context.investmentExpenseModel' is null</response>
        /// <example>
        /// POST: api/InvestmentExpense
        /// </example>
        /// <remarks>
        /// This method creates a investment expense.
        /// </remarks>
        // POST: api/InvestmentExpense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvestmentExpenseModel>> PostInvestmentExpenseModel(InvestmentExpenseModel investmentExpenseModel)
        {
            if (_context.InvestmentExpenseModel == null)
            {
                return Problem("Entity set 'Context.InvestmentExpenseModel'  is null.");
            }
            _context.InvestmentExpenseModel.Add(investmentExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestmentExpenseModel", new { id = investmentExpenseModel.Id }, investmentExpenseModel);
        }

        /// <summary>
        /// this method deletes a investment expense.
        /// </summary>
        /// <param name="id">the id of the investment expense</param>
        /// <returns> a deleted investment expense</returns>
        /// <response code="204">returns no content</response>
        /// <response code="404">if the investment expense is null</response>
        /// <response code="500">if the entity set 'Context.investmentExpenseModel' is null</response>
        /// <example>
        /// DELETE: api/InvestmentExpense/5
        /// </example>
        /// <remarks>
        /// This method deletes a investment expense.
        /// </remarks>

        // DELETE: api/InvestmentExpense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestmentExpenseModel(int id)
        {
            if (_context.InvestmentExpenseModel == null)
            {
                return NotFound();
            }
            var investmentExpenseModel = await _context.InvestmentExpenseModel.FindAsync(id);
            if (investmentExpenseModel == null)
            {
                return NotFound();
            }

            _context.InvestmentExpenseModel.Remove(investmentExpenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method gets the investment expenses by the parameters.
        /// </summary>
        /// <param name="parameters">the parameters</param>
        /// <returns> the investment expenses</returns>


        private bool InvestmentExpenseModelExists(int id)
        {
            return (_context.InvestmentExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
