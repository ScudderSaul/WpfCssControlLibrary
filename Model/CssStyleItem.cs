using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WpfCssControlLibrary.Model
{
    [Table("CssStyleItem")]
    public partial class CssStyleItem
    {
        public CssStyleItem()
        {
            CssColorTypes = new HashSet<CssColorType>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemValue { get; set; }

        public int? StyleOrder { get; set; }

        public int? CssAnimationId { get; set; }

        public virtual CssAnimation? CssAnimation { get; set; }

        public virtual CssStyle CssStyle { get; set; }

        public int? CssStyleId { get; set; }

        public virtual ICollection<CssColorType> CssColorTypes { get; set; } = new HashSet<CssColorType>();
    }
}
