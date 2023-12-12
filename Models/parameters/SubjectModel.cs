using API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters;

/// <summary>
/// This class represents the subject model.
/// </summary>
public class SubjectModel
{
    /// <summary>
    /// Subject Id in the database. 
    /// </summary>
    /// <value> It must be a valid integer
    /// </value>
    [Column("Id")]
    public int Id { get; set; }

    /// <summary>
    /// Name of the subject.
    /// </summary>
    /// <value> It must be a valid string that represents the name of the subject, it can't be null
    /// </value>

    [Required]
    [Column("Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// this is a string that represents the kind of subject (Electiva - Obligatoria).
    /// </summary>
    /// <value> It must be a valid string that represents the kind of subject, it can't be null
    /// </value>
    [Required]
    [Column("Modality")]
    public SubjectModality Modality { get; set; } = SubjectModality.Obligatoria;

    /// <summary>
    /// this is a TeacherModel that represents the teacher that has a subject.
    /// </summary>
    /// <value> It must be a valid TeacherModel
    /// </value>

    [Column("Teacher_Name")]
    public TeacherModel Teacher { get; set; } = null!;



}