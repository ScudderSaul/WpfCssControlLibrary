using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace WpfCssControlLibrary.Model
{
    [Table("CssTransition")]
    public partial class CssTransition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string PropertyName { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public string TimingFunction { get; set; } = string.Empty;

        public string Delay { get; set; } = string.Empty;

        public int? CssStyleId { get; set; } 

        public virtual CssStyle? CssStyle { get; set; }
    }
}
