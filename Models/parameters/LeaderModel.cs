using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters;
/// <summary>
/// This class represents the leader model.
/// </summary>
[Table("Leader")]
public class LeaderModel
{
    /// <summary>
    /// Leader Id in the database.
    /// </summary>
    /// <value> It must be a valid integer
    /// </value>
    [Column("Id")]
    public int Id { get; set; }
    /// <summary>
    /// Name of the leader type.
    /// </summary>
    /// <value> It must be a valid string that represents the name of the leader, it can't be null
    /// </value> 
    [Column("Type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Price of the leader type.
    /// </summary>
    /// <value> It must be a valid decimal that represents the price of the leader, it can't be null</value> 
    [Column("Price")]
    public decimal price { get; set; }

}
