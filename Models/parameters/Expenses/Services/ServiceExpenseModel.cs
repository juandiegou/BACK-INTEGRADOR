using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters.Expenses.Servicess;
/// <summary>
/// this class represents the ServiceExpense expense model, it inherits from ExpenseModel.
/// Also it is a Base of another models of type Services.
/// </summary>
[Table("ServiceExpense")]
public class ServiceExpenseModel : ExpenseModel
{
    /// <summary>
    /// this is a string that represents the name of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the name of the service, it can't be null </value>
    /// <example>
    /// Asesoria
    /// </example>
    [Column("ServiceName")]
    public string ServiceName { get; set; } = null!;
    /// <summary>
    /// this is a string that represents the type of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the type of the service, it can't be null </value>
    /// <example>
    /// Fijo
    /// </example>
    [Column("ServiceType")]
    public string ServiceType { get; set; } = null!;
    /// <summary>
    /// this is a decimal that represents the cost of the service.
    /// </summary>
    /// <value> It must be a valid decimal that represents the cost of the service, it can't be null </value>
    /// <example>
    /// 100.00
    /// </example>
    [Column("ServiceCost")]
    public decimal ServiceCost { get; set; }
}
