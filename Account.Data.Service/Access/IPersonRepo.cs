using Account.Data.Service.Transport;

namespace Account.Data.Service.Access
{
    public interface IPersonRepo
    {
         List<Person> GetEveryone();
    }
}
