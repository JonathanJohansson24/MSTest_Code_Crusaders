using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using test;
namespace OOP_Projekt_I_Grupp_MSTest
{
    [TestClass]
    public class CheckingAccountTests
    {
        [TestInitialize]
        public void Setup()
        {
            UserContext.CurrentUser = new User("JohnDoe", "1234", false)
            {
                Accounts = new List<Accounts>()
            };
        }

        [TestMethod] // Testar så det funkar att skapa ett konto med de giltiga inputs som krävs. 
        public void CreateAccount_Return_ValidInput()
        {
            // Arrange
            string name = "My Checking Account";
            decimal balance = 1000m;
            string currency = "SEK";

            // Act
            var account = CheckingAccount.CreateAccount(name, balance, currency);

            // Assert
            Assert.IsNotNull(account);
            Assert.AreEqual(name, account.Name);
            Assert.AreEqual(balance, account.Balance);
            Assert.AreEqual(currency, account.Currency);
        }

        [TestMethod] // Testar så att ifall vi inte matar in ett namn att det blir defaultname som heter checking account
        public void CreateAccount_EmptyName_UsesDefaultName()
        {
            // Arrange
            string name = "";
            decimal balance = 1000m;
            string currency = "SEK";

            // Act
            var account = CheckingAccount.CreateAccount(name, balance, currency);

            // Assert
            Assert.IsNotNull(account);
            Assert.AreEqual("Checking Account", account.Name);
            Assert.AreEqual(balance, account.Balance);
            Assert.AreEqual(currency, account.Currency);
            Assert.AreEqual(1, UserContext.CurrentUser.Accounts.Count);
        }

        [TestMethod] // Testar så att man inte kan starta ett konto med minus saldo
        //[ExpectedException(typeof(ArgumentException), "Beloppet måste vara större än 0.")]
        public void CreateAccount_InvalidBalance_Return_NotCreated()
        {
            // Arrange
            string name = "My Checking Account";
            decimal balance = -1000m;
            string currency = "SEK";

            // Act
            try
            {
                CheckingAccount.CreateAccount(name, balance, currency);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Beloppet måste vara större än 0.", ex.Message);
            }

            // Verify no account was added
            Assert.AreEqual(0, UserContext.CurrentUser.Accounts.Count);
        }

        [TestMethod]  // kollar så att man använder sig av rätt valuta när man skapar ett konto, dvs USD eller SEK 
        //[ExpectedException(typeof(ArgumentException), "Ogiltig valuta.")]
        public void CreateAccount_InvalidCurrency_Return_NotCreated()
        {
            // Arrange
            string name = "My Checking Account";
            decimal balance = 1000m;
            string currency = "EUR";

            // Act
            try
            {
                CheckingAccount.CreateAccount(name, balance, currency);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex)
            {
            Assert.AreEqual("Ogiltig valuta.", ex.Message);
            }

            // Verify no account was added
            Assert.AreEqual(0, UserContext.CurrentUser.Accounts.Count);
        }

    }
}