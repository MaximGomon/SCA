﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SCA.Domain
{
    public class IdentityEntity
    {
        public IdentityEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }
    }
}
