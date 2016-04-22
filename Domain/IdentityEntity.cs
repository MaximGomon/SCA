using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Domain
{
    public class IdentityEntity
    {
        public IdentityEntity()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        [Key]
        public Guid Id { get; set; }
    }
}
