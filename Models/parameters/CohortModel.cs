using System.ComponentModel.DataAnnotations;
using Api.Models.parameters.Expenses;
using API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters;

/// <summary>
///  This class represents the cohort model.
/// </summary> 


[Table("Cohort")]
public class CohortModel
{
    private List<ExpenseModel>? expense = new List<ExpenseModel>();

    /// <summary>
    /// TCohort Id
    [Column("Id")]
    [ConcurrencyCheck]
    public int Id { get; set; }


    /// <summary>
    /// Type of cohort (TCohort) is a string that represents the type (Postgrado- Maestria - Doctorado) of cohort .
    /// </summary>
    /// <value></value>
    [Column("Type")]
    [Required]
    [ConcurrencyCheck]
    public virtual TypeCohort Type { get; set; } = TypeCohort.Postgrado;

    /// <summary>
    /// Periods is an integer that represents the number of periods of the cohort.
    /// </summary>
    /// <value> Between 1 and 10
    ///  </value>
    [Required]
    [Column("Periods")]
    [ConcurrencyCheck]
    public int periods { get; set; }

    /// <summary>
    /// StartDate is a DateTime that represents the start date of the cohort.
    /// </summary>
    /// <value> It must be a valid date
    /// </value>
    [Required]
    [Column("StartDate")]
    [ConcurrencyCheck]
    public DateTime StartDate { get; set; }
    /// <summary>
    /// Is the modality of the cohort (Presencial - Virtual - Hybrid).
    /// </summary>
    /// <value>
    /// It must be Presencial, Virtual or Hibrida
    /// </value>
    [Required]
    [Column("Modality")]
    [ConcurrencyCheck]
    public virtual ModalityCohort Modality { get; set; } = ModalityCohort.Presencial;

    /// <summary>
    /// This is a boolean that represents if the cohort has and agreement.
    /// </summary>
    /// <value>
    /// It must be true or false
    /// </value>

    [Column("HasAgreement")]
    [ConcurrencyCheck]
    public bool Agreement { get; set; } = false;

    /// <summary>
    /// This is an ExpenseModel that represents the all expense of the cohort.
    /// </summary>
    /// <value>
    /// It must be a valid ExpenseModel
    /// </value>
    ///     
    [Column("Expense_Id")]
    [ConcurrencyCheck]
    public virtual List<ExpenseModel>? Expense { get => expense; set => expense = value; }
    /// <summary>
    /// This is a list of RegistrationModel that represents the all records of registrations of the cohort.
    /// </summary>
    /// <value>
    /// It must be a valid list of RegistrationModel
    /// </value>
    /// 

    [Column("Registration_Id")]
    [ConcurrencyCheck]
    public virtual List<RegistrationModel>? Registration { get; set; } = new List<RegistrationModel>();

    /// <summary>
    /// This is a list of StudentModel that represents the all students of the cohort.
    /// </summary>
    ///  


}
