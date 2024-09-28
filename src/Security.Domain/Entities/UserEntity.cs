namespace Security.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        //public List<Address> Addresses { get; set; }
        //public List<Contact> Contacts { get; set; }

        // Construtor para criar um novo usuário
        public UserEntity(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty");

            Name = name;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        // Método para atualizar o nome do usuário
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
            Name = name;
        }

        // Método para atualizar o email do usuário
        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty");
            Email = email;
        }
    }
}
