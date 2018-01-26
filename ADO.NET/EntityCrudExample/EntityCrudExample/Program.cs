using System;
using System.Linq;

namespace EntityCrudExample
{
    class Program
    {
        static void Main()
        {
            string table = null;
            while (true)
            {
                Console.WriteLine("Please select table:");
                Console.WriteLine("1. Users");
                Console.WriteLine("2. Orders");
                Console.WriteLine("3. Exit");

                Int32.TryParse(Console.ReadLine(), out int userChoise);
                switch (userChoise)
                {
                    case 1:
                        table = "Users";
                        break;
                    case 2:
                        table = "Orders";
                        break;
                    case 3:
                        break;
                    default:
                        continue;
                }
                if (table != null)
                {
                    ManageTable(table);
                    break;
                }
                    
            }
        }

        private static void ManageTable(string table)
        {
            switch (table)
            {
                case "Users":
                    ManageUsers();
                    break;
                case "Orders":
                    ManageOrders();
                    break;
                default:
                    Console.WriteLine("Wrong name!");
                    break;
            }
        }

        private static void ManageOrders()
        {
            while (true)
            {
                Console.WriteLine("Please, select command: (1-6)");
                Console.WriteLine("1. Add new order");
                Console.WriteLine("2. View order info by id");
                Console.WriteLine("3. View all orders");
                Console.WriteLine("4. Modify order by id");
                Console.WriteLine("5. Delete order by id");
                Console.WriteLine("6. Get orders by user id");
                Console.WriteLine("7. Exit");

                bool isExit = false;

                using (var context = new StoreDbContext())
                {
                    Console.Write("Choise: (1-6) ");
                    Int32.TryParse(Console.ReadLine(), out int userChoise);
                    Guid userId;
                    Guid orderId;

                    var cUser = context.Users.First();
                    var cOrder = context.Orders.First();
                    
                    switch (userChoise)
                    {
                        case 1:
                            var newOrder = new Orders();
                            newOrder.Id = Guid.NewGuid();
                            Console.Write("Product: ");
                            newOrder.Product = Console.ReadLine();
                            Console.Write("Price: ");
                            if (Int32.TryParse(Console.ReadLine(), out int price))
                            {
                                newOrder.Price = price;
                            }
                            Console.Write("Quantity: ");
                            if (Int32.TryParse(Console.ReadLine(), out int qty))
                            {
                                newOrder.Qty = qty;
                            }

                            Console.WriteLine("User id");
                            try
                            {
                                userId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            var fuser = context.Users.Find(userId);
                            if (fuser != null)
                                newOrder.IdUser = fuser;

                            context.Orders.Add(newOrder);
                            context.SaveChanges();
                            break;

                        case 2:
                            Console.WriteLine("Enter order id");
                            try
                            {
                                orderId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            var order = context.Orders.Find(orderId);
                            if (order != null)
                                Console.WriteLine($"{order.Id} {order.Product} {order.Price} {order.Qty} {order.IdUser}");
                            break;

                        case 3:
                            foreach (var corder in context.Orders)
                            {
                                Console.WriteLine($"{corder.Id} {corder.Product} {corder.Price} {corder.Qty} {corder.IdUser}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter order id");

                            try
                            {
                                orderId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            context.Orders.Remove(context.Orders.Find(orderId));

                            var changeOrder = new Orders();
                            changeOrder.Id = orderId;

                            Console.Write("Product: ");
                            changeOrder.Product = Console.ReadLine();
                            Console.Write("Price: ");
                            if (Int32.TryParse(Console.ReadLine(), out int nprice))
                            {
                                changeOrder.Price = nprice;
                            }
                            Console.Write("Quantity: ");
                            if (Int32.TryParse(Console.ReadLine(), out int nqty))
                            {
                                changeOrder.Qty = nqty;
                            }

                            Console.WriteLine("User id");
                            try
                            {
                                userId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            var fnewuser = context.Users.Find(userId);
                            if (fnewuser != null)
                                changeOrder.IdUser = fnewuser;

                            context.Orders.Add(changeOrder);
                            context.SaveChanges();
                            break;

                        case 5:
                            Console.WriteLine("Enter order id");

                            try
                            {
                                orderId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            context.Orders.Remove(context.Orders.Find(orderId));
                            context.SaveChanges();
                            break;

                        case 6:
                            throw new NotImplementedException();
                            break;

                        case 7:
                            isExit = true;
                            break;

                        default:
                            Console.WriteLine("Wrong choise, try again");
                            continue;
                    }

                    if (isExit) break;
                }

            }
        }
        
        private static void ManageUsers()
        {
            while (true)
            {
                Console.WriteLine("Please, select command: (1-6)");
                Console.WriteLine("1. Add new user");
                Console.WriteLine("2. View user info by id");
                Console.WriteLine("3. View all users");
                Console.WriteLine("4. Modify user by id");
                Console.WriteLine("5. Delete user by id");
                Console.WriteLine("6. Exit");

                bool isExit = false;

                using (var context = new StoreDbContext())
                {
                    Console.Write("Choise: (1-6) ");
                    Int32.TryParse(Console.ReadLine(), out int userChoise);
                    Guid userId;
                    

                    switch (userChoise)
                    {
                        case 1:
                            var newUser = new Users();
                            newUser.Id = Guid.NewGuid();
                            Console.Write("First name: ");
                            newUser.FirstName = Console.ReadLine();
                            Console.Write("Last name: ");
                            newUser.LastName = Console.ReadLine();
                            Console.Write("Email: ");
                            newUser.Email = Console.ReadLine();

                            context.Users.Add(newUser);
                            context.SaveChanges();
                            break;

                        case 2:
                            Console.WriteLine("Enter user id");
                            try
                            {
                                userId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }
                            
                            var user = context.Users.Find(userId);
                            if(user != null)
                            Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Email}");
                            break;

                        case 3:
                            foreach (var cUser in context.Users)
                            {
                                Console.WriteLine($"{cUser.Id} {cUser.FirstName} {cUser.LastName} {cUser.Email}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter user id");
                            
                            try
                            {
                                userId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            context.Users.Remove(context.Users.Find(userId));

                            var changeUser = new Users();
                            changeUser.Id = userId;
                            Console.Write("First name: ");
                            changeUser.FirstName = Console.ReadLine();
                            Console.Write("Last name: ");
                            changeUser.LastName = Console.ReadLine();
                            Console.Write("Email: ");
                            changeUser.Email = Console.ReadLine();

                            context.Users.Add(changeUser);
                            context.SaveChanges();
                            break;

                        case 5:
                            Console.WriteLine("Enter user id");

                            try
                            {
                                userId = Guid.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Wrong id");
                                continue;
                            }

                            context.Users.Remove(context.Users.Find(userId));
                            context.SaveChanges();
                            break;

                        case 6:
                            isExit = true;
                            break;

                        default:
                            Console.WriteLine("Wrong choise, try again");
                            continue;
                    }

                    if (isExit) break;
                }

            }
        }
    }
}
