using System;
using System.Collections.Generic;
using System.Text;
using MoneyBox;
using Moneybox.App.Domain;
using Xunit;

namespace MoneyBox.tests
{
    public class Accounttests
    {
        [Theory]
        [InlineData(true, 4001)]
        [InlineData(false, 3999)]
        public void LessthanLimit(bool expected, decimal pay)
        {
            //Arrange


            //Act
            bool actual = Moneybox.App.Account.ValidateLessThanLimit(pay);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(true, 499)]
        [InlineData(false, 500)]

        public void Lowfunds(bool expected, decimal balance)
        {
            //Act
            bool actual = Moneybox.App.Account.ValidateLowFunds(balance);

            //Assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(true, 0)]
        [InlineData(true, -1)]
        [InlineData(false, 1)]
        public void NoFunds(bool expected, decimal balance)
        {
            //Act
            bool actual = Moneybox.App.Account.ValidateNoFunds(balance);

            //Assert
            Assert.Equal(expected, actual);

        }

    }
}
