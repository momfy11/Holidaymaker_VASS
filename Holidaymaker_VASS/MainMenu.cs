namespace app;
class MainMenu
{

    public static void Menu()
    {
        bool showMenu = true;

        Console.WriteLine("Main Menu!");
        Console.WriteLine("1) Create User");
        Console.WriteLine("2) Create Booking");
        Console.WriteLine("3) Edit Booking");
        Console.WriteLine("4) View Booking");
        Console.WriteLine("5) History");
        Console.WriteLine("9) Quit");


        while (showMenu)
        {
            string mainoption = Console.ReadLine();

            switch (mainoption)
            {
                case "1":
                    //CreateUser();
                    Console.WriteLine("Creating a user"); // ta bort när vi har en create user method
                    break;
                case "2":
                    //CreateBooking();
                    Console.WriteLine("Creating a booking"); // ta bort när vi har en create booking method
                    break;
                case "3":
                    //EditBooking();
                    Console.WriteLine("editing a booking"); // ta bort när vi har en edit booking method
                    break;
                case "4":
                    //ViewBooking();
                    Console.WriteLine("Viewing a booking"); // ta bort när vi har en view booking method
                    break;
                case "5":
                    //History();
                    Console.WriteLine("Viewing history booking"); //ta bort när vi har en History method
                    break;
                case "9":
                    showMenu = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
