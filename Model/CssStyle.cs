using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace WpfCssControlLibrary.Model
{
    [Table("CssStyle")]
    public partial class CssStyle
    {
        public CssStyle()
        {
            CssTransitions = new HashSet<CssTransition>();
            CssStyleItems = new HashSet<CssStyleItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string StyleName { get; set; } = "NoName";

        public string CssFontSelected { get; set; } = string.Empty;

        public string CssFontSize { get; set; }=string.Empty;

        public string CssFontVariant { get; set; }=string.Empty;

        public string CssFontStyle { get; set; }=string.Empty;

        public string CssFontWeight { get; set; }=string.Empty;

        public virtual ICollection<CssTransition> CssTransitions { get; set; } = new HashSet<CssTransition>();

        public virtual ICollection<CssStyleItem> CssStyleItems { get; set; } = new HashSet<CssStyleItem>();
    }
}
