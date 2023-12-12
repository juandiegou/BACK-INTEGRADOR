using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters.Expenses.Special;
/// <summary>
/// this class represents the InvestmentExpense expense model, it inherits from SpecialExpenseModel.
/// </summary>
[Table("InvestmentExpense")]
public class InvestmentExpenseModel : SpecialExpenseModel
{ }
