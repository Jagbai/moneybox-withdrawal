using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class TransferMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;

        public TransferMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            WithdrawMoney withdraw = new WithdrawMoney(accountRepository, notificationService);
            withdraw.Execute(fromAccountId, amount);
            var to = this.accountRepository.GetAccountById(toAccountId);

            var paidIn = to.PaidIn + amount;
            if (Account.ValidateLessThanLimit(paidIn))
            {
                throw new InvalidOperationException("Account pay in limit reached");
            }
            var Balance = Account.PayInLimit - paidIn;

            if (Account.ValidateLowFunds(Balance))
            {
                this.notificationService.NotifyApproachingPayInLimit(to.User.Email);
            }

            to.Balance = to.Balance + amount;
            to.PaidIn = to.PaidIn + amount;        
            this.accountRepository.Update(to);
        }
    }
}
