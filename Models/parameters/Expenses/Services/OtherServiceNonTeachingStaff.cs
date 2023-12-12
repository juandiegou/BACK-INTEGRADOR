using Api.Models.parameters.Expenses.Servicess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters.Expenses.Services;
/// <summary>
/// this class represents the OtherServiceNonTeachingStaff expense model, it inherits from ServiceExpenseModel.
/// </summary>
[Table("OtherServiceNonTeachingStaff")]
public class OtherServiceNonTeachingStaff : ServiceExpenseModel
{
    /// <summary>
    /// this is a decimal that represents the unit cost of the service.
    /// </summary>
    /// <value> It must be a valid decimal that represents the unit cost of the service, it can't be null </value>
    /// <example>
    /// 100.00
    /// </example>
    [Column("UnitCostService")]
    public decimal UnitCostService { get; set; }
    /// <summary>
    /// this is an integer that represents the quantity of the service.
    /// </summary>
    /// <value> It must be a valid integer that represents the quantity of the service, it can't be null </value>
    /// <example>
    ///  1
    /// </example> 
    [Column("QuantityService")]
    public int QuantityService { get; set; }

}