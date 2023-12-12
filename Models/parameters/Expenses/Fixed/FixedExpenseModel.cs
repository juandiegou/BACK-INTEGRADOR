using Api.Models.parameters.Expenses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.parameters.Expenses.Fixed;
/// <summary>
/// this class represents the FixedExpense expense model, it inherits from ExpenseModel.
/// Also it is a Base of another models of type Fixed.
/// </summary>
[Table("FixedExpense")]
public class FixedExpenseModel : ExpenseModel
{
    /// <summary>
    /// this is a string that represents the criterion of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the criterion of the service, it can't be null </value>
    /// <example>
    /// Pago derechos de publicación de artículos científicos, edición de textos en inglés y otros
    /// </example>
    [Column("Criterion")]
    public string Criterion { get; set; } = null!;
    /// <summary>
    /// this a decimal that represents the unit value of the service.
    /// </summary>
    /// <value> It must be a valid decimal that represents the unit value of the service, it can't be null </value>
    /// <example>
    /// 100.00
    /// </example>
    [Column("UnitValue")]
    public decimal UnitValue { get; set; }
    /// <summary>
    /// this is an integer that represents the quantity of the service.
    /// </summary>
    /// <value> It must be a valid integer that represents the quantity of the service, it can't be null </value>
    /// <example>
    /// 3
    /// </example>
    [Column("Quantity")]
    public int Quantity { get; set; }
    /// <summary>
    /// tthis is a string that represents the type of the cost.
    /// </summary>
    /// <value> It must be a valid string that represents the type of the cost, it can't be null </value>
    /// <example>
    /// Fijo
    /// </example>
    [Column("TypeCost")]
    public string TypeCost { get; set; } = null!;

}
