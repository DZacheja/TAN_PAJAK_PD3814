using System;

namespace LegacyApp
{
    public class UserService
    {
        //AddUser_ShouldAddUserCorrectly
        //AddUser_ShouldFail_IncorrectEmail

        //SOLID
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            //Przesniesienie walidacji do klasy user -> Single Responsibility
            if (!user.CheckUserData()) return false;

            //Wyodrębienie Limitu do osobnej funkcji
            GetUserCreditLimit(client, user);

            //Wyodrębienie sprawdzenia do osobnej funkcji
            if (ValidUserCreditLimit(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool ValidUserCreditLimit(User user)
        {
            return (!user.HasCreditLimit && !(user.CreditLimit < 500));

        }

        private void GetUserCreditLimit(Client client, User user)
        {
            if (client.Name == "VeryImportantClient")
            {
                //Skip credit limit
                user.HasCreditLimit = false;
            } else if (client.Name == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.FirstName, user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            } else
            {
                //Do credit check
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.FirstName, user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
        }
    }
}
