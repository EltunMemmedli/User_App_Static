using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace User_App_Static
{
    internal static class UserController
    {
        private static List<User> users = new List<User>();

        public static void AddUsers( User User)
        {
            users.Add(User) ;
        }

        public static List<User> GetUsers()
        {

            return users;
        }

        public static void SignIn(string email, string password)
        {
            bool valid = false;

            foreach (User allUsers in users)
            {
                
                if(email == allUsers.Email && password == allUsers.Password)
                {
                    valid = true;

                    Console.WriteLine("Logined Succesfully!");

                    Console.WriteLine($"\nWelcome {allUsers.Name}\n\n" +
                                        $"Your info:\n\n" +
                                        $"Name: {allUsers.Name},\n" +
                                        $"Surname: {allUsers.Surname},\n" +
                                        $"Age: {allUsers.Age},\n" +
                                        $"Email: {allUsers.Email},\n" +
                                        $"Role:  {allUsers.UserRole}");
                    break;

                }

            }

            if (!valid)
            {
                Console.WriteLine("Cannot find the user!");
            }

        }

        public static void AddNewUser(string name,
                                        string surname,
                                        int age,
                                        string email,
                                        string password,
                                        UserRole userRole)
        {
            User UpdatedUser = new User(
                                        name = name,
                                        surname = surname,
                                        age = age,
                                        email = email,
                                        password = password,
                                        UserRole.User
                                        );

            users.Add(UpdatedUser);

        }

        public static void DeleteUser(int IDofUser)
        {
            users.RemoveAt(IDofUser);
            Console.Clear();
            Console.WriteLine("User has succesfully deleted!");
            bool valid = false;
            int counter = 1;
            foreach (User notDeleted in users)
            {

                if (notDeleted.UserRole == UserRole.User)
                {
                    valid = true;
                    Console.WriteLine($"\nUser's info:\n" +
                                          $"User ID: {counter++},\n" +
                                          $"Name: {notDeleted.Name},\n" +
                                          $"Surname: {notDeleted.Surname},\n" +
                                          $"Age: {notDeleted.Age},\n" +
                                          $"Email: {notDeleted.Email},\n" +
                                          $"Role: {notDeleted.UserRole}");
                }

            }
            if (valid)
            {
                return;
            }

        }

        public static void UpdateUser(
            int UserID,
            string name,
            string surname,
            int age,
            string email,
            string password,
            UserRole userRole
            )
        {
            User newUser = new User
                 (
                     name = name,
                     surname = surname,
                     age = age,
                     email = email,
                     password = password,
                     UserRole.User
                 );

            users[UserID] = newUser;
            Console.Clear();
            Console.WriteLine("User has succesfully updated!");
            bool valid = false;
            int counter = 1;
            foreach (User notDeleted in users)
            {

                if (notDeleted.UserRole == UserRole.User)
                {
                    valid = true;
                    Console.WriteLine($"\nUser's info:\n" +
                                          $"User ID: {counter++},\n" +
                                          $"Name: {notDeleted.Name},\n" +
                                          $"Surname: {notDeleted.Surname},\n" +
                                          $"Age: {notDeleted.Age},\n" +
                                          $"Email: {notDeleted.Email},\n" +
                                          $"Role: {notDeleted.UserRole}");
                }

            }
            if (valid)
            {
                return;
            }

        }

        public static void UpdateProfil(string password, int propertyID, string newProperty)
        {
            foreach (User Property in users)
            {
                if (password == Property.Password)
                {
                    User NewUser = Property;

                    if (propertyID == 1) //Name
                    {
                        NewUser.Name = newProperty;
                    }
                    else if (propertyID == 2) //Surname
                    {
                        NewUser.Surname = newProperty;
                    }
                    else if (propertyID == 3) //Age
                    {


                        if (int.TryParse(newProperty, out int NewProperty) && NewProperty > 0)
                        {
                            NewUser.Age = int.Parse(newProperty);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Imvalid syntax!\n");
                            break;
                        }
                    }
                    else if (propertyID == 4) //Email
                    {
                        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                        Regex regex = new Regex(pattern);

                        bool valid = regex.IsMatch(newProperty);
                        if (!(string.IsNullOrEmpty(newProperty)) && valid)
                        {
                            NewUser.Email = newProperty;
                        }
                        else
                        {
                            Console.WriteLine("Invalid email!");
                        }
                    }
                    else if (propertyID == 5) //Password
                    {
                        if (!(string.IsNullOrEmpty(newProperty)))
                        {
                            NewUser.Password = newProperty;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Can not find!");
                    }
                    NewUser = Property;
                }
            }
        }


        public static void SignUp(string name,
                                    string surname,
                                    int age,
                                    string email,
                                    string password,
                                    UserRole userRole)
        {

            User newUser = new User(name, surname, age, email, password, UserRole.User);
            users.Add(newUser);

            int counter = 1;
            Console.Clear();
            

               
                    Console.WriteLine($"\nUser - ID: {counter++}" +
                                        $"\nYour info:\n" +
                                        $"Name: {newUser.Name},\n" +
                                        $"Surname: {newUser.Surname},\n" +
                                        $"Age: {newUser.Age},\n" +
                                        $"Email: {newUser.Email},\n" +
                                        $"Role: {newUser.UserRole}");
                
            

        }
    }
}
