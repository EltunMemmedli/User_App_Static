using User_App_Static;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

User Admin = new User("Eltun", "Memmedli", 18, "eltun.memmedli.06@gmail.com", "2006", UserRole.Admin);
User User_1 = new User("Cavid", "Memmedli", 15, "cavid.memmedli.09@gmail.com", "2009", UserRole.User);
User User_2 = new User("Ehmed", "Qurbanli", 25, "ehmed.qurbanli.99@gmail.com", "1999", UserRole.User);

UserController.AddUsers(Admin);
UserController.AddUsers(User_1);
UserController.AddUsers(User_2);

Secim:
Console.WriteLine("Please, select the option\n\n" +
                        "1.Sign In,\n" +
                        "2.Sign Up\n" +
                        "=================");

string Secim = Console.ReadLine();
int secim;

if(int.TryParse(Secim, out secim) && secim > 0 && secim < 3)
{
    if(secim == 1)
    {
        Console.Clear();
    email:
        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
        Regex regex = new Regex(pattern);


        Console.WriteLine("Please, enter your email");
        string email = Console.ReadLine();
        Console.Clear();

        bool Ismatch = regex.IsMatch(email);
        if(!(string.IsNullOrEmpty(email)) && Ismatch)
        {
        password:
            Console.Clear();
            Console.Write("Please, enter your password: ");
            string password = Console.ReadLine();

            if (!(string.IsNullOrEmpty(password)))
            {
                Console.Clear();
                UserController.SignIn(email, password);

                List<User> allUsers = UserController.GetUsers();

                foreach (User User in allUsers)
                {
                    if(password == User.Password && email == User.Email && User.UserRole == UserRole.Admin)
                    {
                        Option:
                        Console.WriteLine($"\n\nSelect the option\n" +
                                            $"1.Add new user,\n" +
                                            $"2.Delete user,\n" +
                                            $"3.Update user,\n" +
                                            $"4.Update profil\n" +
                                            $"====================");

                        string Option = Console.ReadLine();
                        int option;

                        if(int.TryParse(Option,out option) && option > 0 && option < 5)
                        {
                            if(option == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Please, enter user's name");
                                string name = Console.ReadLine();
                                Console.Clear();

                                Console.WriteLine("Please, enter user's surname");
                                string surname = Console.ReadLine();
                                Console.Clear();
                                Age:
                                Console.Write("Please, enter user's age: ");
                                string Age = Console.ReadLine();
                                int age;

                                if(int.TryParse(Age, out age) && age > 0)
                                {
                                    Console.Clear();
                                    Email:
                                    Console.WriteLine("Please, enter user's email");
                                    string Email = Console.ReadLine();
                                    bool IsmMatch = regex.IsMatch(Email);

                                    if(!(string.IsNullOrEmpty(Email)) && IsmMatch)
                                    {
                                        Console.Clear();
                                        Password:
                                        Console.Write("Please, enter user's password: ");
                                        string Password = Console.ReadLine();

                                        if (!(string.IsNullOrEmpty(Password)))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("User added succesfully!\n");
                                            UserController.AddNewUser(name, surname, age, Email, Password, UserRole.User);


                                            List<User> Update = UserController.GetUsers();
                                            int counter = 1;
                                            foreach (User Updated in Update)
                                            {
                                                if (Updated.UserRole == UserRole.User)
                                                {
                                                    Console.WriteLine($"User's info:\n\n" +
                                                                        $"User - ID: {counter++},\n" +
                                                                        $"Name: {Updated.Name},\n" +
                                                                        $"Surname: {Updated.Surname},\n" +
                                                                        $"Age: {Updated.Age},\n" +
                                                                        $"Email: {Updated.Email},\n" +
                                                                        $"Role: {Updated.UserRole}\n");
                                                    
                                                }


                                            }
                                        Kec:
                                            Thread.Sleep(2000);
                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                            string Kec = Console.ReadLine();

                                            if (Kec.ToLower() == "f")
                                            {
                                                Console.Clear();
                                                goto Option;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                goto Kec;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid password!");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            goto Password;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid email!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Email;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid age!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Age;
                                }

                            }

                            else if(option == 2)
                            {
                                Console.Clear();
                            Delete:
                                bool valid = false;
                                int counter = 1;
                                int say = allUsers.Count;
                                foreach (User users in allUsers)
                                {

                                    if (users.UserRole == UserRole.User)
                                    {

                                        valid = true;
                                        Console.WriteLine(
                                                          $"\nUser's info:\n" +
                                                          $"User ID: {counter++},\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Role: {users.UserRole}");
                                    }
                                }
                                if (valid)
                                {
                                    Console.Write("\n\nEnter the User ID: ");
                                    string UserID = Console.ReadLine();
                                    int Userid;

                                    if (int.TryParse(UserID, out Userid) && Userid > 0 && Userid < say + 1)
                                    {
                                        UserController.DeleteUser(Userid);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid syntax!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Delete;
                                    }
                                }
                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Option;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }


                            }

                            else if(option == 3)
                            {
                                Console.Clear();
                            Updated:
                                bool valid = false;
                                int counter = 1;
                                int say = allUsers.Count;
                                foreach (User users in allUsers)
                                {

                                    if (users.UserRole == UserRole.User)
                                    {

                                        valid = true;
                                        Console.WriteLine(
                                                          $"\nUser's info:\n" +
                                                          $"User ID: {counter++},\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Role: {users.UserRole}");
                                    }
                                }
                                if (valid)
                                {
                                    Console.Write("\n\nEnter the User ID: ");
                                    string UserID = Console.ReadLine();
                                    int Userid;

                                    if (int.TryParse(UserID, out Userid) && Userid > 0 && Userid < say + 1)
                                    {
                                        Console.Clear();
                                        Sifre:
                                        Console.Write("Enter the user's password: ");
                                        string OldPassword = Console.ReadLine();

                                        foreach (User Password in allUsers)
                                        {
                                            if(Password.UserRole == UserRole.User)
                                            {
                                                if(OldPassword == Password.Password)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Enter user's new name");
                                                    string name = Console.ReadLine();
                                                    Console.Clear();

                                                    Console.WriteLine("Enter user's new surname");
                                                    string surname = Console.ReadLine();
                                                    Console.Clear();

                                                Age1:
                                                    Console.WriteLine("Enter user's new age");
                                                    string age = Console.ReadLine();
                                                    int Age;

                                                    if (int.TryParse(age, out Age) && Age > 0)
                                                    {
                                                        Console.Clear();
                                                    Eamil1:
                                                        Console.WriteLine("Enter user's new email");
                                                        string Email = Console.ReadLine();
                                                        bool ismatch = regex.IsMatch(Email);

                                                        if (!(string.IsNullOrEmpty(Email)) && ismatch)
                                                        {
                                                            Console.Clear();
                                                        Password1:
                                                            Console.Write("Enter user's new password: ");
                                                            string Password1 = Console.ReadLine();

                                                            if (!(string.IsNullOrEmpty(Password1)))
                                                            {
                                                                Console.Clear();
                                                                UserController.UpdateUser(Userid, name, surname, Age, Email, Password1, UserRole.User);
                                                                Kec:
                                                                Thread.Sleep(2000);
                                                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                                string Kec = Console.ReadLine();

                                                                if (Kec.ToLower() == "f")
                                                                {
                                                                    Console.Clear();
                                                                    goto Option;
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                                    goto Kec;
                                                                }
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Invalid syntax!");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                goto Password1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Invalid syntax!");
                                                            Thread.Sleep(1000);
                                                            Console.Clear();
                                                            goto Eamil1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Invalid syntax!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        goto Age1;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Invalid syntax!");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();
                                                    goto Sifre;
                                                }
                                            }

                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid syntax!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Updated;
                                    }
                                }
                                
                            }

                            else if(option == 4)
                            {
                                Console.Clear();
                                Password:
                                Console.Write("Enter your password: ");
                                string UpdateProp = Console.ReadLine();

                                if (!(string.IsNullOrEmpty(UpdateProp)) && UpdateProp == User.Password)
                                {

                                    Console.Clear();
                                    bool matchFound = false;


                                    foreach (User users in allUsers)
                                    {

                                        if (password == users.Password)
                                        {
                                            matchFound = true;

                                            Console.WriteLine(
                                                              $"Your info:\n" +
                                                              $"Name: {users.Name},\n" +
                                                              $"Surname: {users.Surname},\n" +
                                                              $"Age: {users.Age},\n" +
                                                              $"Email: {users.Email},\n" +
                                                              $"Password: {users.Password},\n" +
                                                              $"Role: {users.UserRole}");
                                            break;
                                        }

                                    }

                                    Property:
                                    Console.Write("\nEnter the property ID: ");
                                    string OldPropertyID = Console.ReadLine();
                                    int OldProperty;

                                    if (int.TryParse(OldPropertyID, out OldProperty) && OldProperty < 6)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new property");
                                        string newProperty = Console.ReadLine();
                                        Console.Clear();
                                        UserController.UpdateProfil(UpdateProp, OldProperty, newProperty);
                                        bool matchFound1 = false;


                                        foreach (User users in allUsers)
                                        {

                                            if (password == users.Password)
                                            {
                                                matchFound1 = true;

                                                Console.WriteLine(
                                                                  $"Your info:\n" +
                                                                  $"Name: {users.Name},\n" +
                                                                  $"Surname: {users.Surname},\n" +
                                                                  $"Age: {users.Age},\n" +
                                                                  $"Email: {users.Email},\n" +
                                                                  $"Password: {users.Password},\n" +
                                                                  $"Role: {users.UserRole}");
                                                break;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invail option!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Property;
                                    }
                                }
                                else
                                {

                                    Console.Clear();
                                    Console.WriteLine("Invail password!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Password;
                                }

                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Option;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invail option!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Option;
                        }
                    }

                    else if(password == User.Password && email == User.Email && User.UserRole == UserRole.User)
                    {

                    Option:
                        Console.WriteLine("\n\nSelect option:\n" +
                                             "1.Update profile\n" +
                                             "===================");
                        string secim_1 = Console.ReadLine();
                        int Secim_1;

                        if (int.TryParse(secim_1, out Secim_1) && Secim_1 > 0 && Secim_1 < 2)
                        {
                            Console.Clear();
                            Console.Write("Enter your password: ");
                            string UpdateProp = Console.ReadLine();

                            if (!(string.IsNullOrEmpty(UpdateProp)) && UpdateProp == User.Password)
                            {

                                Console.Clear();
                                bool matchFound = false;


                                foreach (User users in allUsers)
                                {

                                    if (password == users.Password)
                                    {
                                        matchFound = true;

                                        Console.WriteLine(
                                                          $"Your info:\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Password: {users.Password},\n" +
                                                          $"Role: {users.UserRole}");
                                        break;
                                    }

                                }

                                Console.Write("\nEnter the property ID: ");
                                string OldPropertyID = Console.ReadLine();
                                int OldProperty;

                                if (int.TryParse(OldPropertyID, out OldProperty) && OldProperty < 6)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter new property");
                                    string newProperty = Console.ReadLine();
                                    Console.Clear();
                                    UserController.UpdateProfil(UpdateProp, OldProperty, newProperty);
                                    bool matchFound1 = false;


                                    foreach (User users in allUsers)
                                    {

                                        if (password == users.Password)
                                        {
                                            matchFound1 = true;

                                            Console.WriteLine(
                                                              $"Your info:\n" +
                                                              $"Name: {users.Name},\n" +
                                                              $"Surname: {users.Surname},\n" +
                                                              $"Age: {users.Age},\n" +
                                                              $"Email: {users.Email},\n" +
                                                              $"Password: {users.Password},\n" +
                                                              $"Role: {users.UserRole}");
                                            break;
                                        }

                                    }
                                }
                            }
                        Kec:
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                            string Kec = Console.ReadLine();

                            if (Kec.ToLower() == "f")
                            {
                                Console.Clear();
                                goto Option;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                goto Kec;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid syntax!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Option;
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invail password!");
                Thread.Sleep(1000);
                Console.Clear();
                goto password;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invail email!");
            Thread.Sleep(1000);
            Console.Clear();
            goto email;
        }

    }

    else if(secim == 2)
    {
        Console.Clear();

        Console.WriteLine("Enter your name ");
        string name = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter your surname");
        string surname = Console.ReadLine();
        Console.Clear();
    Age:
        Console.WriteLine("Enter your age");
        string Age = Console.ReadLine();
        int age;

        if (int.TryParse(Age, out age) && age > 0)
        {
            Console.Clear();
        Email2:
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();

            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex regex = new Regex(pattern);

            bool IsMatch = regex.IsMatch(email);
            if (!(string.IsNullOrEmpty(email)) && IsMatch)
            {
                Console.Clear();
            Password2:
                Console.WriteLine("Enter your password");
                string password = Console.ReadLine();
                if (!(string.IsNullOrEmpty(password)))
                {
                    UserController.SignUp(name, surname, age, email, password, UserRole.User);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid syntax!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Password2;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid syntax!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Email2;
            }


        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid syntax!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Age;
        }



    }
}
else
{
    Console.Clear();
    Console.WriteLine("Invalid selection!");
    Thread.Sleep(1000);
    Console.Clear();
    goto Secim;
}

