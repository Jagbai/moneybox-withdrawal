# Moneybox Money Withdrawal

The solution contains a .NET core library (Moneybox.App) which is structured into the following 3 folders:

* Domain - this contains the domain models for a user and an account, and a notification service.
* Features - this contains two operations, one which is implemented (transfer money) and another which isn't (withdraw money)
* DataAccess - this contains a repository for retrieving and saving an account (and the nested user it belongs to)

## Moneybox Money Withdrawal

## Changes made

## Withdraw Money
Created execute method within Withdraw so that aftenew balance is calculated the balance is passed through 2 if statements that check whether the user has an insufficent amount of funds to make the Withdrawal and whether they have low funds. After which the function whill store the new balance within the from account as well as the amount withdrawn. The account repository is then updated.

## Transfer Money
Made changes to the execute method to use the WithdrawMoney execute method as and made changes to the original code to make use of the new behavioural elements of the Account class.

## Account
Made changes to the Account class to become more rich in behaviour creating reusable methods that could be used within the classes Withdraw Money and Transfer Money allowing important values to not be exposed within the two classes
