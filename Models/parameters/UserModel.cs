using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models.Enums;
using API.Models.parameters;

namespace Api.Models.parameters;
/// <summary>
/// This class represents the user model.
/// </summary>
[Table("Users")]
public class UserModel
{
    /// <summary>
    /// user Id in the database.
    /// </summary>
    /// <value> It must be a valid integer</value> 
    [Column("Id")]
    public int Id { get; set; }
    /// <summary>
    /// Name of the user. 
    /// </summary>
    /// <value> It must be a valid string that represents the name of the user, it can't be null </value>
    [Column("Usermame")]
    public string Usermame { get; set; } = null!;
    /// <summary>
    /// Leader of the user is a category that represent the salary leader.
    /// </summary>
    /// <value> It must be a valid LeaderModel </value>
    [Column("Name")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// The email of the user.
    /// </summary>
    /// <value> It must be a valid string that represents the email of the user, it can't be null </value>
    /// <example>example@example</example>
    [Column("Email")]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    /// <summary>
    /// The password of the user. This is a hashed password.
    /// </summary>
    /// <value> It must be a valid string that represents the password of the user, it can't be null </value>
    /// <example> HsyOwq9wq8wq </example>
    /// <remarks> This is a hashed password </remarks>
    [Column("Password")]
    [Required]
    public string Password { get; set; } = null!;
    /// <summary>
    /// The role of the user. 
    /// </summary>
    /// <value> It must be a valid number that represents the role of the user, it can't be null </value>
    /// <example> 1 </example>
    /// <remarks> 1 is for admin, 2 is for user, 3 is for developer </remarks>
    [Column("Role")]
    [Required]
    public UserRole Role { get; set; }

    /// <summary>
    /// The permissions of the user.
    /// </summary>
    /// <value> It must be a valid list of permissions that represents the permissions of the user, it can't be null </value>
    /// <example> canCreate </example>
    /// <remarks> This is a list of permissions </remarks>
    /// <seealso cref="PermissionsModel"/>
    /// <seealso cref="UserPermission"/>
    /// 
    [Column("Permissions")]
    [Required]
    public List<PermissionsModel> Permissions { get; set; } = new List<PermissionsModel>();


    public UserModel()
    {
        // This is a list of permissions that the user has by default.
        //UserPermission.canCreate, UserPermission.canRead, UserPermission.canLogin, UserPermission.canLogout, UserPermission.canRegister, UserPermission.canChangePassword, UserPermission.canChangeEmail, UserPermission.canChangeUsername
        Permissions = new List<PermissionsModel>();
        Permissions.Add(new PermissionsModel() { Name = "canCreate", Description = "This permission allows the user to create a new user", Type = UserPermission.canCreate });
        Permissions.Add(new PermissionsModel() { Name = "canRead", Description = "This permission allows the user to read a user", Type = UserPermission.canRead });
        Permissions.Add(new PermissionsModel() { Name = "canLogin", Description = "This permission allows the user to login", Type = UserPermission.canLogin });
        Permissions.Add(new PermissionsModel() { Name = "canLogout", Description = "This permission allows the user to logout", Type = UserPermission.canLogout });
        Permissions.Add(new PermissionsModel() { Name = "canRegister", Description = "This permission allows the user to register", Type = UserPermission.canRegister });
        Permissions.Add(new PermissionsModel() { Name = "canChangePassword", Description = "This permission allows the user to change the password", Type = UserPermission.canChangePassword });
        Permissions.Add(new PermissionsModel() { Name = "canChangeEmail", Description = "This permission allows the user to change the email", Type = UserPermission.canChangeEmail });
        Permissions.Add(new PermissionsModel() { Name = "canChangeUsername", Description = "This permission allows the user to change the username", Type = UserPermission.canChangeUsername });
    }





}
