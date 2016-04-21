namespace SCA.Domain
{
    public class Lead : IdentityEntity
    {
        public virtual LeadType Type { get; set; }
        public virtual Contact Buyer { get; set; }
    }
}
