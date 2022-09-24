using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace WpfCssControlLibrary.Model
{
    [Table("CssColorType")]
    public partial class CssColorType
    {
        public CssColorType()
        {
            CssColors = new HashSet<CssColor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string ColorType { get; set; } 

        public string Angle { get; set; } = string.Empty;

        public string Repeats { get; set; } = string.Empty;

        public string Shape { get; set; } = string.Empty;

        public string Center { get; set; } = string.Empty;

        public string Size { get; set; }     

        public int CssStyleItemId { get; set; }

        public virtual CssStyleItem CssStyleItem { get; set; }

        public virtual ICollection<CssColor> CssColors { get; set; } = new HashSet<CssColor>();


    }
}
