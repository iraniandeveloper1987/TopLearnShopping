namespace TopLearn.Core.Repository.Interfaces.FilterAttributes
{
     public interface IFilterAttributeService
    {
        bool HasPermission(int permissionId, string userName);
    }
}
