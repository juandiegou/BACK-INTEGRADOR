using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters.Expenses;
/// <summary>
/// this class represents the TravelExpense expense model, it inherits from ExpenseModel.
/// </summary> 
[Table("TravelExpense")]
public class TravelExpenseModel : ExpenseModel
{
    /// <summary>
    /// this is a string that represents the destination of the expense.
    /// </summary>
    /// <value> It must be a valid string that represents the destination of the expense, it can't be null </value>
    [Column("Destination")]
    public string Destination { get; set; } = null!;
    /// <summary>
    /// this an integer that represents the number of people of the expense travels.
    /// </summary>
    /// <value> It must be a valid integer that represents the number of people of the expense travels, it can't be null </value>
    [Column("NumberPeople")]
    public int NumberPeople { get; set; }
    /// <summary>
    /// this is a decimal that represents the transport cost($) of the expense.
    /// </summary>
    /// <value> It must be a valid decimal that represents the transport cost($) of the expense, it can't be null </value>
    [Column("TransportCost")]
    public decimal TransportCost { get; set; }
    /// <summary>
    /// this is a decimal that represents the travel cost($) of the expense.
    /// </summary>
    /// <value> It must be a valid decimal that represents the travel cost($) of the expense, it can't be null </value>
    [Column("TravelCost")]
    public decimal TravelCost { get; set; }
    /// <summary>
    /// this an integer that represents the number of travels of the expense.
    /// </summary>
    /// <value> It must be a valid integer that represents the number of travels of the expense, it can't be null </value>
    [Column("NumberTravel")]
    public int numberTravel { get; set; }



}
