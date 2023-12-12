using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Models.parameters;
/// <summary>
/// This class represents the teacher model.
/// </summary>
[Table("Teacher")]
public class TeacherModel
{
    /// <summary>
    /// Teacher Id in the database.
    /// </summary>
    /// <value> It must be a valid integer</value> 
    [Column("Id")]
    public int Id { get; set; }
    /// <summary>
    /// Name of the teacher. 
    /// </summary>
    /// <value> It must be a valid string that represents the name of the teacher, it can't be null </value>
    [Column("Name")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Leader of the teacher is a category that represent the salary leader.
    /// </summary>
    /// <value> It must be a valid LeaderModel </value>
    [Column("Leader_Id")]
    public LeaderModel Leader { get; set; } = null!;

}
