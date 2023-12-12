using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters;
/// <summary>
///  This class represents the registration of cohort model.
/// </summary>

public class RegistrationModel
{
    /// <summary>
    /// Registration Id
    /// </summary>
    /// <value> It must be a valid integer </value>
    [Column("Id")]
    public int Id { get; set; }

    /// <summary>
    /// this is a decimal that represents the amount of the registration.
    /// </summary>
    /// <value> Number between 0 and 100000000 </value>
    [Column("Amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// this is a Model that represents the student that has a Registration.
    /// </summary>
    /// <value> It must be a valid StudentModel </value>
    [Column("Student_Id")]
    public StudentModel Student { get; set; } = null!;

    /// <summary>
    /// this is a Model that represents a list of subjects that has a Registration.
    /// </summary>
    /// <value>It must be a valid list of SubjectModel </value>
    [Column("Subject_Id")]
    public List<SubjectModel> Subject { get; set; } = null!;


}
