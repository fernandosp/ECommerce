namespace ECommerce.Integration.Business.Interfaces
{
    public interface IIntegration<out T> where T : new()
    {
        T Post(string endPoint, object obj);
    }
}
