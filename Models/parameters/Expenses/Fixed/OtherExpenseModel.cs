using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.parameters.Expenses.Fixed;
/// <summary>
/// this class represents the OtherExpense expense model, it inherits from FixedExpenseModel.
/// </summary>
[Table("OtherExpense")]
public class OtherExpenseModel : FixedExpenseModel
{

}
