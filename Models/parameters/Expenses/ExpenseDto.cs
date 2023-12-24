/// this is a DTO class for Expense
/// 

namespace Api.Models.parameters.Expenses;

/// <summary>
/// this class represents all the expenses.
/// </summary>
/// 

public class ExpenseDto
{

    public int Id { get; set; }
    public double total { get; set; }
    public string? UnitName { get; set; }
    public decimal? HourlyRate { get; set; }
    public int? NumberHours { get; set; }
    public string? Destination { get; set; }
    public int? NumberPeople { get; set; }
    public decimal? TransportCost { get; set; }
    public decimal? TravelCost { get; set; }
    public int? numberTravel { get; set; }
    public string? Criterion { get; set; }
    public decimal? UnitValue { get; set; }
    public int? Quantity { get; set; }
    public string? TypeCost { get; set; }
    public decimal? UnitCostService { get; set; }
    public int? QuantityService { get; set; }
    public string? DescriptionService { get; set; } = null!;
    public string? TeacherName { get; set; } = null!;
    public int? NumberHoursService { get; set; }
    public string? TypeCostService { get; set; } = null!;
    public string? TypeService { get; set; } = null!;
    public decimal? PercentageService { get; set; }
    public decimal? CostService { get; set; }

}