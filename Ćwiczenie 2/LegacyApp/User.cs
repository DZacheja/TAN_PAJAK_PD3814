using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public bool CheckUserData()
        {
            return (ChceckUserName() && CheckEmail() && ChceckAge());
        }

        private bool ChceckUserName()
        {
            return (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName));
        }

        private bool CheckEmail()
        {
            return (EmailAddress.Contains("@") && EmailAddress.Contains("."));
        }

        private bool ChceckAge()
        {
            var now = DateTime.Now;
            int age = now.Year - DateOfBirth.Year;
            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day)) age--;
            return (age >= 21);
        }

        public override string ToString() {
            return FirstName + " " + LastName;
        }
    }
}