using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCA.Domain
{
    public class SystemSetting : IdentityEntity
    {
        [Required]
        [MaxLength(64)]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
