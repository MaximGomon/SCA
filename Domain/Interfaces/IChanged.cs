using System;

namespace SCA.Domain.Interfaces
{
    public interface IChanged
    {
        DateTime? ModifyDate { get; set; }
    }
}
