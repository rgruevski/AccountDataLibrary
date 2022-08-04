using Account.Data.Service.Transport;

namespace Account.Data.Service.Access
{
    public class PersonRepo : IPersonRepo
    {
        public List<Person> GetEveryone() => new AccountDao<Person>().LoadAllRecords("Person");
    }
}
