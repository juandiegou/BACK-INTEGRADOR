using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Api.Models.parameters.Expenses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters.Expenses.Special;
/// <summary>
/// this class represents the SpecialExpense expense model, it inherits from ExpenseModel.
/// Also it is a Base of another models.
/// </summary>
[Table("SpecialExpense")]
public class SpecialExpenseModel : ExpenseModel
{
    /// <summary>
    /// this is a string that represents the type of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the type of the service, it can't be null </value>
    /// <example>
    /// "Fijo"
    /// </example>
    [Column("TypeService")]
    [ConcurrencyCheck]
    public string TypeService { get; set; } = null!;
    /// <summary>
    /// this is a string that represents the description of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the description of the service, it can't be null </value>
    [Column("DescriptionService")]
    [ConcurrencyCheck]
    public string DescriptionService { get; set; } = null!;
    /// <summary>
    /// this is a decimal that represents the percentage of the Special Expense.
    /// </summary>
    /// <value> It must be a valid decimal between (0,1)  that represents the percentage of the Special Expense, it can't be null </value>
    [Range(0, 1)]
    [Column("PercentageService")]
    [ConcurrencyCheck]
    public decimal PercentageService { get; set; }
    /// <summary>
    /// this is a decimal that represents the cost of the Special Expense.
    /// </summary>
    /// <value> It must be a valid decimal that represents the cost of the Special Expense, it can't be null </value>
    /// <example>
    /// 100.00
    /// </example>
    [Column("CostService")]
    [ConcurrencyCheck]
    public decimal CostService { get; set; }

}
