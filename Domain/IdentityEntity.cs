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
        public virtual Guid Id { get; set; }
    }
}
