using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Domain.Interfaces
{
    public interface IChanged
    {
        [Column(TypeName = "datetime2")]
        DateTime? ModifyDate { get; set; }
    }
}
