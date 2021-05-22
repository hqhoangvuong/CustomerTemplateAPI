using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI.Models
{
    public class SystemMasterConfig
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string ConfigName { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ConfigValue { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
