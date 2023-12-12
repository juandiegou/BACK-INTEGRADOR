using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters;

/// <summary>
/// This class represents the leader model.
/// </summary>
/// 
[Table("Program")]
public class ProgramModel
{
    /// <summary>
    /// Program Id in the database.
    /// </summary>
    /// <value> It must be a valid integer </value>
    [Column("Id")]
    public int Id { get; set; }
    /// <summary>
    /// Name of the program.
    /// </summary>
    /// <value> It must be a valid string that represents the name of the program, it can't be null </value>
    [Column("Name")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Modality of the program.
    /// </summary>
    /// <value> It must be a valid string that represents the modality of the program, it can't be null </value>
    [Column("Modality")]
    public string Modality { get; set; } = null!;
    /// <summary>
    /// This is a list of subjects that the program has.
    /// </summary>
    /// <value> It must be a valid list of teachers. </value>
    [Column("Teacher_Id")]
    public List<TeacherModel> Teachers { get; set; } = null!;

}