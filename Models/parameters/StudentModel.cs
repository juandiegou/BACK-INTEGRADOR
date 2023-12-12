using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters;
/// <summary>
/// This class represents the student model.
/// </summary> 
[Table("Student")]
public class StudentModel
{
    /// <summary>
    /// Student Id in the database.
    /// </summary>
    /// <value> It must be a valid integer </value>
    [Column("Id")]
    public int Id { get; set; }

    /// <summary>
    /// Name of the student.
    /// </summary>
    /// <value> It must be a valid string</value>
    [Required]
    [Column("Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Document number of the student.
    /// </summary>
    /// <value> It must be a valid string that represents the document number</value>
    [Column("Document")]
    public string Document { get; set; } = null!;

    /// <summary>
    /// Email of the student.
    /// </summary>
    /// <value> It must be a valid string that represents the email</value> 
    [Column("Email")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Phone number of the student.
    /// </summary>
    /// <value> It must be a valid string that represents the phone number</value>
    [Column("Phone")]
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Address of the student. 
    /// </summary>
    /// <value> It must be a valid string that represents the address </value>
    [Column("Address")]
    public string Address { get; set; } = null!;

    /// <summary>
    /// This is a string that represents the code of the student in the academic system.
    /// </summary>
    /// <value> It must be a valid string that represents the code </value>
    [Column("Code")]
    public string Code { get; set; } = null!;

    /// <summary>
    /// This is a List of DiscountModel that represents the all discounts of the student.
    /// </summary>
    /// <value> It must be a valid list of DiscountModel</value>
    [Column("Discount_Id")]
    public List<DiscountModel> Discount { get; set; } = null!;

}
