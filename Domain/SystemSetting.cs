using System.ComponentModel.DataAnnotations;

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
