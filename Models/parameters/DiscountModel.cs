using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.parameters;

/// <summary>
/// This class represents the discount model.
/// </summary>
[Table("Discount")]
public class DiscountModel
{
    /// <summary>
    /// Discount Id in the database.
    /// </summary>
    /// <value> It must be a valid integer
    /// </value>
    [Column("Id")]
    public int Id { get; set; }

    /// <summary>
    /// It is a decimal that represents the percentage of the discount over the registation.
    /// </summary>
    /// <value> It must be a valid decimal between 0 and 1
    /// </value>
    [Required]
    [Column("Percentage")]
    [Range(0, 1)]
    public decimal Percentage { get; set; }

    /// <summary>
    /// It is a decimal that represents the cost of the discount over the registation.
    /// </summary>
    /// <value> It must be a valid decimal between 0 and 100000000000
    /// </value>
    [Column("Cost")]
    public decimal Cost { get; set; }

    /// <summary>
    /// It is a string that represents the type of the discount.
    /// </summary>
    /// <value> It must be a valid string that represents the type of the discount
    /// </value>
    [Column("Type")]
    public string Type { get; set; } = null!;




}
