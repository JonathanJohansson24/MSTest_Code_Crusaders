using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class CreateUser
    {
        public static User AddUser(string username, string pin, bool role = false) // TestMetoden
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Användarnamn kan inte vara tomt.");
            }

            if (string.IsNullOrEmpty(pin))
            {
                throw new ArgumentException("Pin kan inte vara tomt.");
            }

            var newUser = new User(username, pin, role);
            Start.CustomerList.Add(newUser);

            return newUser;
        }
        public static void AddUser()
        {
            Console.Write("\n\tAnge Användarnamn: ");
            string username = Console.ReadLine();

            Console.Write("\n\tAnge pin: ");
            string pin = Console.ReadLine();

            bool role = false;

            User newCustomer = new User(username, pin, role);
            newCustomer.Accounts = new List<Accounts>();

            Start.CustomerList.Add(newCustomer);

            Console.WriteLine($"\n\tAnvändare {username} Skapats!");
            Console.ReadKey();
        }
    }
}
