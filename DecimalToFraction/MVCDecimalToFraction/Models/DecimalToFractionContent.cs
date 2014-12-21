using System.ComponentModel.DataAnnotations;

namespace MVCDecimalToFraction.Models
{
  public class DecimalToFractionContent
  {
    [Required]
    [Display(Name = "Decimal")]
    public string Num { get; set; }

  }
}