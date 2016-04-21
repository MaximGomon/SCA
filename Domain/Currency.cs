using System.ComponentModel.DataAnnotations;

namespace SCA.Domain
{
    /// <summary>
    /// Справочник валюк
    /// </summary>
    public class Currency : DictionaryEntity
    {
        [MaxLength(4)]
        public virtual string BankCode { get; set; }
    }
}
