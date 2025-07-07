namespace ECommerce.Entities.Aggregates.UserAggregate
{
    //for user and list of orders
    public class User
    {

        public User()
        {
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}

