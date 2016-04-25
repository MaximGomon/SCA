namespace SCA.Domain
{
    public class Lead : NamedEntity
    {
        public virtual LeadType Type { get; set; }
        public virtual Contact Buyer { get; set; }
    }
}
