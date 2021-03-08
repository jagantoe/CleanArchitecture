using System;

namespace CleanArchitecture.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            SetName(name);
            SetEmail(email);
        }

        private void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException();
        }
        private void SetEmail(string email)
        {
            Name = email ?? throw new ArgumentNullException();
        }
    }
}
