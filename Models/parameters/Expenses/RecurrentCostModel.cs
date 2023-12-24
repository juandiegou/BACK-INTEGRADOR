using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters.Expenses;
/// <summary>
/// this class represents the RecurrentCost expense model, it inherits from ExpenseModel.
/// </summary>
[Table("RecurrentCost")]
public class RecurrentCostModel : ExpenseModel
{
    /// <summary>
    /// this is a string that represents the unit name of the expense.
    /// </summary>
    /// <value> It must be a valid string that represents the unit name of the expense, it can't be null </value>
    [Column("UnitName")]
    [ConcurrencyCheck]
    public string UnitName { get; set; } = null!;
    /// <summary>
    /// this is a decimal that represents the hourly rate($) of the expense.
    /// </summary>
    /// <value> It must be a valid decimal that represents the hourly rate($) of the expense, it can't be null </value>
    [Column("HourlyRate")]
    [ConcurrencyCheck]
    public decimal HourlyRate { get; set; }

    /// <summary>
    /// this is a integer that represents the number of hours of the expense.
    /// </summary>
    /// <value> It must be a valid integer that represents the number of hours of the expense, it can't be null </value> 

    [Column("NumberHours")]
    [ConcurrencyCheck]
    public int NumberHours { get; set; }

}
