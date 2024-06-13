using LaboPabSoap.Entities;

namespace LaboPabSoap.Service
{
    public class UserService : IUserService
    {
        public string RegisterUser(User user)
        {
            if (Validate(user))
            {
                // some registration logic
                return $"User {user.EmailAddress} registered!";
            }
            return "Cannot register user.";
        }

        private bool Validate(User user)
        {
            if (user == null)
                return false;
            if (string.IsNullOrEmpty(user.EmailAddress))
                return false;
            return true;
        }
    }
}