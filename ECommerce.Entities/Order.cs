namespace ECommerce.Entities
{
    public class Order
    {

        public Order(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Order name cannot be empty.", nameof(name));
            if (name.Length>50) throw new ArgumentException("Order name cannot be longer than 50 characters.", nameof(name));
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
