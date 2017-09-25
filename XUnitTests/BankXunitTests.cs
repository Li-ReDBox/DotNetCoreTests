using System;
using Xunit;
using BankAccountNS;

namespace XUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.Equal<double>(expected, actual);
        }

        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutofRange()
        {
            double beginingBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginingBalance);

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            Assert.Contains(BankAccount.DebitAmountLessThanZeroMessage, ex.Message);
        }

        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginingBalance = 11.99;
            double debitAmount = 100.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginingBalance);

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            Assert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, ex.Message);
        }
    }
}
