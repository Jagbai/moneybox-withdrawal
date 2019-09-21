using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class WithdrawMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;

        public WithdrawMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {
            // TODO:

            //Set local version of fromAccount
            var from = this.accountRepository.GetAccountById(fromAccountId);
            //recalculate balance
            var fromBalance = from.Balance - amount;
            //Throw exceptions
            if (Account.ValidateNoFunds(fromBalance))
            {
                throw new InvalidOperationException("Insufficient funds to make transfer");
            }
            //if there is low money in account then send email
            if (Account.ValidateLowFunds(fromBalance))
            {
                this.notificationService.NotifyFundsLow(from.User.Email);
            }

            from.Balance = from.Balance - amount;
            from.Withdrawn = from.Withdrawn - amount;

            this.accountRepository.Update(from);
        }
    }
}
