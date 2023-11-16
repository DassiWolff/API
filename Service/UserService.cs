using Entities;
using Repository;
//Rename folder name to Services
//Interface IUserService is missing
namespace Service
{
    public class UserService
    {

        UserRepository userRepository = new UserRepository();
        public User addUser (User user)
        {
            if (checkPassword(user.Password) < 2)
            {
                return null;
            }
            return userRepository.addUser(user);
        }



        public User getUser(string userName, string password)
        {
            return userRepository.getUser(userName, password);
        }


        public User editUser( User userToUpdate)
        {

            return userRepository.editUser(userToUpdate);
        }

        private int checkPassword(string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
            }
            return -1;
        }

    }
}