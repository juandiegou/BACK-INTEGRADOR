using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters.Expenses;
/// <summary>
/// this class represents the BASE expense model.
/// </summary>
[Table("Expense")]
public class ExpenseModel
{
    /// <summary>
    /// Expense Id in the database.
    /// </summary>
    /// <value> It must be a valid integer </value>
    [Column("Id")]
    public int Id { get; set; }
    /// <summary>
    /// this a number that represents the total of the expense.
    /// </summary>
    /// <value> It must be a valid double that represents the total of the expense, it can't be null </value>
    [Column("Total")]
    public double total { get; set; }

}
