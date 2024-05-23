using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP_Projekt_I_Grupp_MSTest
{
    [TestClass]
    public class CreateUserTests
    {
        [TestInitialize]
        public void Setup()
        {
            Start.CustomerList = new List<User>();
        }
        [TestMethod] // Testar så det funkar att skapa en användare med de giltiga inputs som krävs. 
        public void AddUser_Return_ValidInput()
        {
            // Arrange
            string username = "TestUser";
            string pin = "5678";

            // Act
            var user = CreateUser.AddUser(username, pin);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(pin, user.Pin);
            Assert.IsFalse(user.Role);
        }

        [TestMethod] // Testar så att man inte kan skapa en användare utan användarnamn
        [Description("Tests to see that a user is not created if no username is assigned.")]
        public void AddUser_EmptyUsername_ThrowsException()
        {
            // Arrange
            string username = "";
            string pin = "5678";

            // Act & Assert
            try
            {
                CreateUser.AddUser(username, pin);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Användarnamn kan inte vara tomt.", ex.Message);
            }

            // Verify no user was added
            Assert.AreEqual(0, Start.CustomerList.Count);
        }

        [TestMethod] // Testar så att man inte kan skapa en användare utan pin
        [Description("Tests to see that a user is not created if no pin is assigned.")]
        public void AddUser_EmptyPin_ThrowsException()
        {
            // Arrange
            string username = "TestUser";
            string pin = "";

            // Act & Assert
            try
            {
                CreateUser.AddUser(username, pin);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Pin kan inte vara tomt.", ex.Message);
            }

            // Verify no user was added
            Assert.AreEqual(0, Start.CustomerList.Count);
        }

        [TestMethod]  // Testar att användaren läggs till korrekt
        [Description("Tests if the user gets added properly if correct information is put.")]
        public void AddUser_ValidUser_AddsToUserContext()
        {
            // Arrange
            string username = "TestUser";
            string pin = "5678";

            // Act
            var user = CreateUser.AddUser(username, pin);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(1, Start.CustomerList.Count);
            Assert.AreEqual(username, (Start.CustomerList[0].Username));
        }
    }
}

