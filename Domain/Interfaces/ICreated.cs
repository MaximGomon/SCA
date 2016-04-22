using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Domain.Interfaces
{
    public interface ICreated
    {
        [Column(TypeName = "datetime2")]
        DateTime CreateDate { get; set; }
    }
}
