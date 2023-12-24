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
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the student model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetStudentModel, PutStudentModel, PostStudentModel, DeleteStudentModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    //[Authorize]
    public class StudentController : ControllerBase
    {
        private readonly Context _context;

        public StudentController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method returns a list of students.
        /// </summary>
        /// <returns>
        /// a list of students.
        /// </returns>
        /// <response code="200">returns the list of students.</response>
        /// <response code="404">if the list of students is null.</response>
        /// <response code="500">if the entity set 'Context.StudentModel' is null.</response>
        /// <example>
        // GET: api/Student
        // </example>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModel()
        {
            if (_context.StudentModel == null)
            {
                return NotFound();
            }
            return await _context.StudentModel.ToListAsync();
        }

        /// <summary>
        /// this method returns a student by id.
        /// </summary>
        /// <returns>
        /// a student by id.
        /// </returns>
        /// <response code="200">returns the student by id.</response>
        /// <response code="404">if the student by id is null.</response>
        /// <response code="500">if the entity set 'Context.StudentModel' is null.</response>
        /// <example>
        // GET: api/Student/5
        // </example>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(int id)
        {
            if (_context.StudentModel == null)
            {
                return NotFound();
            }
            var studentModel = await _context.StudentModel.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> PutStudentModel(int id, StudentModel studentModel)
        {
            Console.WriteLine("id: " + id);
            if (id != studentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                _ = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(studentModel);
        }


        /// <summary>
        /// this method creates a student.
        /// </summary>
        /// <returns>
        /// a student.
        /// </returns>
        /// <response code="201">returns the student.</response>
        /// <response code="400">if the student is null.</response>
        /// <response code="500">if the entity set 'Context.StudentModel' is null.</response>
        /// <example>
        // POST: api/Student
        // </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
            if (_context.StudentModel == null)
            {
                return Problem("Entity set 'Context.StudentModel'  is null.");
            }

            if (studentModel.Discount != null)
            {
                var discounts = new List<DiscountModel>();
                foreach (var discount in studentModel.Discount)
                {
                    var temp = _context.DiscountModel.Add(discount);
                    if (temp != null)
                    {
                        discounts.Add(temp.Entity);
                    }
                }
                studentModel.Discount = discounts;
            }
            _ = _context.StudentModel.Add(studentModel);
            _ = await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModel", new { id = studentModel.Id }, studentModel);
        }


        /// <summary>
        /// this method deletes a student.
        /// </summary>
        /// <returns>
        /// a student.
        /// </returns>
        /// <response code="200">returns the student.</response>
        /// <response code="404">if the student is null.</response>
        /// <response code="500">if the entity set 'Context.StudentModel' is null.</response>
        /// <example>
        // DELETE: api/Student/5
        // </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentModel(int id)
        {
            if (_context.StudentModel == null)
            {
                return NotFound();
            }

            StudentModel? studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel != null)
            {
                if (studentModel.Discount != null)
                {
                    foreach (var discount in studentModel.Discount)
                    {
                        _ = _context.DiscountModel.Remove(discount);
                    }
                }
                _ = _context.StudentModel.Remove(studentModel);
                _ = await _context.SaveChangesAsync();
                return Ok(studentModel);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// this method if the student exists.
        /// </summary>
        /// <returns>
        /// a boolean that represents if the student exists.
        /// </returns>


        private bool StudentModelExists(int id)
        {
            return (_context.StudentModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
