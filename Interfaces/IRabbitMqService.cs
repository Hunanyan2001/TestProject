using Pomelo.EntityFrameworkCore.MySql.Metadata.Internal;

namespace TestProject.Interfaces
{
    public interface IRabbitMqService
    {
        void SendMessage(object obj);
        void SendMessage(string message);
        Task<List<string>> ReceiveMessages();
    }
}
