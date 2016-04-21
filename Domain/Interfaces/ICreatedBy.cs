namespace SCA.Domain.Interfaces
{
    public interface ICreatedBy : ICreated
    {
        SystemUser CreatedBy { get; set; }
    }
}
