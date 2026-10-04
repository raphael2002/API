using UserApi.Models;

namespace UserApi.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();

        public IEnumerable<User> GetAll() => _users;

        public User Get(int id) => _users.FirstOrDefault(u => u.Id == id);

        public User Create(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return user;
        }

        public bool Update(int id, User updated)
        {
            var existing = Get(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Email = updated.Email;
            existing.Age = updated.Age;

            return true;
        }

        public bool Delete(int id)
        {
            var user = Get(id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }
    }
}
