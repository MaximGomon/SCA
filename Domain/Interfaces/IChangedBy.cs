namespace SCA.Domain.Interfaces
{
    public interface IChangedBy: IChanged
    {
        SystemUser ChangedBy { get; set; }
    }
}
