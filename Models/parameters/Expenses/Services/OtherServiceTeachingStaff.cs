using Microsoft.EntityFrameworkCore;
using Api.Models.parameters.Expenses.Servicess;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters.Expenses.Services;
/// <summary>
/// this class represents the OtherServiceTeachingStaff expense model, it inherits from ServiceExpenseModel.
/// </summary>
[Table("OtherServiceTeachingStaff")]
public class OtherServiceTeachingStaff : ServiceExpenseModel
{
    /// <summary>
    /// this is a string that represents the description of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the description of the service, it can't be null </value>
    /// <example>
    /// Incentivo por coordinación programa. Solo se reconoce el incentivo correspondiente al año 2023, a razón de 10 horas por mes según lo
    /// establecido en la Resolución 085 de 2009 Art. 3lit. a, Art. 4 lit. b y Art. 5 lit. b.
    /// </example>
    [Column("DescriptionService")]
    public string DescriptionService { get; set; } = null!;
    /// <summary>
    /// this is a string that represents the name of the teacher.
    /// </summary>
    /// <value> It must be a valid string that represents the name of the teacher, it can't be null </value>
    [Column("TeacherName")]
    public string TeacherName { get; set; } = null!;
    /// <summary>
    /// this is a integer that represents the number of hours of the service.
    /// </summary>
    /// <value> It must be a valid integer that represents the number of hours of the service, it can't be null </value>
    /// <example>
    /// 10
    /// </example>
    [Column("NumberHoursService")]
    public int NumberHoursService { get; set; }
    /// <summary>
    /// this is a decimal that represents the cost per hour of the service.
    /// </summary>
    /// <value> It must be a valid decimal that represents the cost per hour of the service, it can't be null </value>
    /// <example>
    /// 100.00
    /// </example>
    [Column("CostHourlyService")]
    public decimal CostHourlyService { get; set; }
    /// <summary>
    /// this is a string that represents the type of the service.
    /// </summary>
    /// <value> It must be a valid string that represents the type of the service, it can't be null </value>
    /// <example>
    /// Fijo
    /// </example>
    [Column("TypeCostService")]
    public string TypeCostService { get; set; } = null!;

}
