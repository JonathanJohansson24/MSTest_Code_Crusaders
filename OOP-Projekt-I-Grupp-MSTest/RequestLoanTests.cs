using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Projekt_I_Grupp_MSTest
{
    [TestClass]
    public class RequestLoanTests
    {
        [TestMethod]
        [Description("Test to see that the method to loan a maximum of 5 times your total amount works")]
        public void CalculateMaxLoan_TotalCapital_1000_Return_5000()
        {
            //Arrange
            decimal totalCapital = 1000m;
            //Act
            decimal maxLoan = RequestLoan.TestCalculateMaxLoan(totalCapital);

            //Assert

            Assert.AreEqual(5000m, maxLoan);
        }

        [TestMethod]
        [Description("Test to see that the interestrate works properly")]
        public void CalculateInterest_LoanAmount_1000_Return_50()
        {
            // Arrange
            decimal loanAmount = 1000m;

            // Act
            decimal interest = RequestLoan.TestCalculateInterest(loanAmount);

            // Assert
            Assert.AreEqual(50m, interest);
        }
        [TestMethod]
        [Description("Test to see that the maximum u can borrow works properly if u have 1000 on your account")]
        public void LoanAmount_Input1000_MaxLoan5000_ReturnsTrueAndLoanAmount1000()
        {
            // Arrange
            string input = "1000";
            decimal maxLoan = 5000m;

            // Act
            bool result = RequestLoan.TestTryGetLoanAmount(input, maxLoan, out decimal loanAmount);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1000m, loanAmount);
        }

        [TestMethod]
        [Description("Test to see that the input user puts in is incorrect and doesnt add a value to the loans")]
        public void LoanAmount_InvalidInput_ReturnsFalseAndLoanAmount0()
        {
            // Arrange
            string input = "invalid";
            decimal maxLoan = 5000m;

            // Act
            bool result = RequestLoan.TestTryGetLoanAmount(input, maxLoan, out decimal loanAmount);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0m, loanAmount);
        }

        [TestMethod]
        [Description("Test to see if u try to loan more then the maximum limit for loans is exceeded and it doesnt work.")]
        public void LoanAmount_Input6000_MaxLoan5000_ReturnsFalseAndLoanAmount0()
        {
            // Arrange
            string input = "6000";
            decimal maxLoan = 5000m;

            // Act
            bool result = RequestLoan.TestTryGetLoanAmount(input, maxLoan, out decimal loanAmount);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0m, loanAmount);
        }
    }
}
