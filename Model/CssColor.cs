using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WpfCssControlLibrary.Model
{
    [Table("CssColor")]
    public partial class CssColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string ColorValue { get; set; } = string.Empty;

        public string Stop { get; set; } = String.Empty;

        public int? ColorOrder { get; set; }

        public int? CssColorTypeId { get; set; }

        public virtual CssColorType? CssColorType { get; set; }
    }
}
