//TestProjekt

Kritiska delar och potentiella fel
De delar jag har valt att granska och kolla efter eventuella fel, samt göra tester utav på detta projekt är dessa tre:
Skapa ett konto (CreateAccount)
Skapa en användare (CreateUser)
Begäran om lån (RequestLoan)
De potentiella felen jag tänkte kunde inträffa är dessa som kommer nedan, samt vilka tester jag har valt att utföra: 

1. Skapa ett konto (CheckingAccount)

Potentiella fel:
Vad händer om man skapar ett konto utan att ange namn? 
Vad händer om man försöker skapa ett konto med en totalsumma av 0 eller mindre?
Vad händer om man väljer fel valuta?

Tester:
CreateAccount_Return_ValidInput: Först testar jag om det faktiskt skapas ett konto om man matar in rätt parametrar. 
CreateAccount_EmptyName_UsesDefaultName:
Här testar jag så att om man inte anger ett namn för kontot som skapas så använder sig programmet av det förbestämda defaultvärdet på ett Checking Account

CreateAccount_InvalidBalance_Return_NotCreated: 
Här testar jag så att ifall om man matar in felaktig summa, så är det 0 eller mindre att det inte skapas ett konto ändå. 

CreateAccount_InvalidCurrency_Return_NotCreated:
I detta test går jag igenom så att det inte skapas ett konto utifrån att man inte använder sig av SEK eller USD som är de valutor appen hanterar.


2. Skapa en användare (CreateUser)
   
Potentiella fel:
Att man inte kan skapa en användare utan att mata in ett användarnamn
Samma här att man inte kan skapa en användare utan att mata in ett lösenord
Användare läggs inte till korrekt i kundlistan.

Tester:
AddUser_Return_ValidInput: Först testar jag så att en användare som skapats på korrekt sätt fungerar. 
AddUser_EmptyUsername_ThrowsException:
Här lämnar jag användarnamnet tomt för att se om det blir en exception

AddUser_EmptyPin_ThrowsException: 
Och samma här att om jag lämnar lösenordet tomt så blir det en exception. 

AddUser_ValidUser_AddsToUserContext: 
Här testar jag så att ifall allt matats in korrekt även ser till att den lägger till den skapade användaren på rätt sätt.


3. Begäran om lån (RequestLoan)

Potentiella fel:
Att beräkningen av hur man får ut sitt maximala belopp man är kapabel att låna går rätt till. 
Att beräkningen på hur mycket ränta man får på sitt lån går rätt till.
Att man inte ska kunna låna mera pengar än sitt totala maxbelopp man kan låna
Att det inte blir fel om man skulle mata in fel parametrar. 

Tester:
CalculateMaxLoan_TotalCapital_1000_Return_5000:
Här testar jag så beräkningen går rätt till ifall man har 1000 totalt att man max kan låna 5000, dvs 5 gånger så mycket pengar man har.

CalculateInterest_LoanAmount_1000_Return_50:
Här testar jag så att räntesatsen stämmer.

LoanAmount_Input1000_MaxLoan5000_ReturnsTrueAndLoanAmount1000: 
Här testar jag att beloppet man vill låna är tillåtet och inom maxgränsen.

LoanAmount_InvalidInput_ReturnsFalseAndLoanAmount0: 
Här testar jag ifall om jag matar in fel saker så skapas inget lån. 

LoanAmount_Input6000_MaxLoan5000_ReturnsFalseAndLoanAmount0: 
Här testar jag försöka skapa ett lån som är över maxbeloppsgränsen på hur mycket jag får låna, vilket returnerar att jag inte kan låna och inget lån genomförs. 
















// The project

The Code-crusader bank is a group project for school. The program is coded in C# in .NET. It's a program that resembles a simple bank system.
There are seventeen different classes in our program.

These are all of our classes:
Our program has seventeen different classes;

Accounts:
This is a base/parent class where the users can create new bank accounts.

Checking accounts:
This is a subclass from 'Accounts'. It contains a method that create new accounts.

Create user:
A class where the admin can create new users for the program.

ExchangeRate:
A class where the admin can change the ExchangeRate

Loan:
A class for creating new loans.

Logo:
Shows the bank-logo.

Menu:
A class that writes out the menues. There's one seperate menu for the user and one for the admin.

PrintAccounts:
This class print the bank-accounts for the users.

Program:
Just calls the method StartBank()

RequestLoan:
In this class you request and execute bank-loans.

SavingAccounts:
This is also a subclass based on 'Accounts'. Here the user can open new Saving accounts.

Start:
This is a class that contains the already existing users and their bank-accounts.

Transfer:
In this class you manage the transfers between different accounts.

TransferLog:
A class for creating TransferLogs to save the transferhistory.

TransferUser:
Here you can transfer money to different users.

Users:
A class for creating new users.

UserContext:
This is a class that contains two static Users, one CurrentUsers and one TargetUser.


Starting the application: 

The first step when you start the program is the loginscreen: 
Here the user can choose wether to log in as an admin or a user! 
The user has 3 chances to log in to the application if its wrong the third time the application will close. 

If you log in as a user you get transported to the usermenu wich has the following choices: 

1. View Accounts

   Prints out all the current accounts for the logged in user
3. Transfer

   Lets the user transfer money between its own accounts
4. Transfer to another user

   Lets the user transfer money to another user that has accounts in the bank
6. Open a savingsaccount

   Lets the user open up a savings account, and gets the opportunity to choose the currency,

   And gets interestrate on the money they put in.
8. Open a checking account

    Lets the user open up a checking account, and gets the opportunity to choose the currency
10. Transfer history

     Shows all the logged transfers the user has made.
12. Loan request

    Lets the user request a loan thats not exceeds the amount of the users balance * five. 
14. Log out

    Logs out, and returns to the start page.
16. Exit the program

    Shuts down the program.

If you log in as an Admin you get transported to the AdminMenu wich has the following choices: 

1. Create new user

   Lets the Admin create a new user with unique username and password
3. Set exchangerates

   Lets the admin set the exchangerates for the current currencies
5. Log out

   Logs out, and returns to the start page.
7. Exit the program

   Shuts down the program.

Link to our UML diagram
   
   https://lucid.app/lucidchart/0d1aeb14-297a-4446-b6f1-fcdba2e0a0c2/edit?viewport_loc=-1849%2C-1508%2C4992%2C2319%2CHWEp-vi-RSFO&invitationId=inv_91ced300-da0e-4d9a-b4f3-0d6fb5ca0b66

Link to our Scrum board wich we made in Trello

https://trello.com/b/WPAKfdAF/projekt-oop
