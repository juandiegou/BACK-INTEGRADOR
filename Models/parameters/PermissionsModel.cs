using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models.Enums;

namespace Api.Models.parameters;

/// <summary>
/// This class represents the permission model.
/// </summary>
/// <value> It must be a valid integer</value>
/// <example> 1 </example>
/// 

[Table("Permissions")]
public class PermissionsModel
{
    /// <summary>
    /// Permission Id in the database.
    /// </summary>
    /// <value> It must be a valid integer</value>
    /// <example> 1 </example>
    [Column("Id")]
    public int Id { get; set; }

    /// <summary>
    /// It is a string that represents the name of the permission.
    /// </summary>
    /// <value> It must be a valid string that represents the name of the permission, it can't be null </value>
    /// <example> canCreate </example>
    [Column("Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// It is a string that represents the description of the permission.
    /// </summary>
    /// <value> It must be a valid string that represents the description of the permission, it can't be null </value>
    /// <example> This permission allows the user to create a new user </example>
    [Column("Description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// It is a string that represents the type of the permission.
    /// </summary>
    /// <value> It must be a valid string that represents the type of the permission, it can't be null </value>
    /// <example> user </example>
    [Column("Type")]
    public UserPermission Type { get; set; }
}