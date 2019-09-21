using System;

namespace Moneybox.App
{
    public class Account
    {
        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; set; }

        public decimal Withdrawn { get; set; }

        public decimal PaidIn { get; set; }

        public static bool ValidateLessThanLimit(decimal Pay)
        {
            if (Pay > PayInLimit)
            {
                return true;
            }
            return false;

        }
        public static bool ValidateLowFunds(decimal Balance)
        {
            if (Balance < 500m)
            {
                return true;
            }
            return false;

        }
        public static bool ValidateNoFunds(decimal Balance)
        {
            if (Balance <= 0)
            {
                return true;
            }
            return false;

        }

    }
}
