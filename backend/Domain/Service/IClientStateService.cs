namespace Domain.Service
{
    public interface IClientStateService
    {
        int UserId { get; set; }
        string UserName { get; set; }
    }
}