using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters.Expenses.Special;
/// <summary>
/// this class represents the TransferExpense expense model, it inherits from SpecialExpenseModel.
/// </summary>
[Table("TransferExpense")]
public class TransferExpenseModel : SpecialExpenseModel
{ }