using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCRUD.Entity;
using ConsoleCRUD.Repository;
using ConsoleCRUD.Tools;

namespace ConsoleCRUD.View
{
    public class LoginView
    {
        public void Show()
        {
            while (true)
            {
                UserManagementEnum choice = RenderMenu();

                switch (choice)
                {
                    case UserManagementEnum.Select:
                        {
                            GetAll();
                            break;
                        }
                    case UserManagementEnum.Insert:
                        {
                            Add();
                            break;
                        }
                    case UserManagementEnum.Delete:
                        {
                            Delete();
                            break;
                        }
                    case UserManagementEnum.Update:
                        {
                            Update();
                            break;
                        }
                    case UserManagementEnum.Exit:
                        {
                            return;
                        }
                }
            }
        }
        private UserManagementEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Users management: ");
                Console.WriteLine("[P]rint all users");
                Console.WriteLine("[A]dd user");
                Console.WriteLine("[U]pdate user");
                Console.WriteLine("[D]elete user");
                Console.WriteLine("c[l]ose application");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "P":
                        {
                            return UserManagementEnum.Select;
                        }
                    case "A":
                        {
                            return UserManagementEnum.Insert;
                        }
                    case "D":
                        {
                            return UserManagementEnum.Delete;
                        }
                    case "L":
                        {
                            return UserManagementEnum.Exit;
                        }
                    case "U":
                        {
                            return UserManagementEnum.Update;
                        }
                    default:
                        {
                            Console.WriteLine("Something went wrong");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAll()
        {
            Console.Clear();
            UsersRepository usersRepository = new UsersRepository();
            List<Users> users = usersRepository.GetAll();

            foreach (Users user in users)
            {
                Console.WriteLine("Id : {0}", user.Id);
                Console.WriteLine("Username : {0}", user.username);
                Console.WriteLine("Last Name : {0}", user.password);
                Console.WriteLine("email : {0}", user.email);
                Console.WriteLine("\n\n");

            }

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            Users user = new Users();
            UsersRepository creatUser = new UsersRepository();

            Console.WriteLine("Add new User:");
            try
            {
                Console.Write("Id=  ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("username=  ");
                user.username = Console.ReadLine();
                Console.Write("password=  ");
                user.password = Console.ReadLine();
                Console.Write("email=  ");
                user.email = Console.ReadLine();
                creatUser.Insert(user);

                Console.WriteLine("User added successfully.");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id.");
                Console.ReadKey(true);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Already have this ID in DATABASE.");
                Console.ReadKey(true);
            }

        }
        private void Update()
        {
            Console.Clear();

            Users user = new Users();
            UsersRepository updateUser = new UsersRepository();

            Console.WriteLine("Update User:");
            try
            {
                Console.Write("Id=  ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("username=  ");
                user.username = Console.ReadLine();
                Console.Write("password=  ");
                user.password = Console.ReadLine();
                Console.Write("email=  ");
                user.email = Console.ReadLine();
                updateUser.Update(user);

                Console.WriteLine("User update successfully.");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id.");
                Console.ReadKey(true);
            }
        }
        private void Delete()
        {
            Console.Clear();

            Users user = new Users();
            UsersRepository deleteUser = new UsersRepository();

            Console.WriteLine("Delete User: ");
            try
            {
                Console.Write("User Id= ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                deleteUser.Delete(user);

                Console.WriteLine("User delete successfully.");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id.");
                Console.ReadKey(true);
            }
        }
    }
}
