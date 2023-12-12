using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models.parameters.Expenses.Fixed;
/// <summary>
/// this class represents the GeneralExpense expense model, it inherits from FixedExpenseModel.
/// </summary>
[Table("GeneralExpense")]
public class GeneralExpenseModel : FixedExpenseModel
{

}
