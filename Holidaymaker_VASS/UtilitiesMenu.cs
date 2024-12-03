using System.ComponentModel.Design;

namespace app;

public class UtilitiesMenu
{
    

    public bool pool = false;
    public bool entertainment = false;
    public bool kidsClub = false;
    public bool restaurant = false;
    public bool gym = false;
    
    public UtilitiesMenu()
    {
        
    }

    public void Menu()
    { 
        bool showMenu = true;
        while (showMenu)
        {
            Console.WriteLine($"1. Pool {pool}");
            Console.WriteLine($"2. Entertainment {entertainment}");
            Console.WriteLine($"3. Kids Club {kidsClub}");
            Console.WriteLine($"4. Restaurant {restaurant}");
            Console.WriteLine($"5. Gym {gym}");
            Console.WriteLine("B. Go Back");

            var input = Console.ReadLine();
            if (input is not null)
            {
                switch (input)
                {
                    case("1"):
                        pool = !pool;
                        break;
                    case("2"):
                        entertainment = !entertainment;
                        break;
                    case("3"):
                        kidsClub = !kidsClub;
                        break;
                    case("4"):
                        restaurant = !restaurant;
                        break;
                    case("5"):
                        gym = !gym;
                        break;
                    case("b"):
                        Console.WriteLine("Go Back!");
                        showMenu = false;
                        //Go back to Filter Menu
                        break;
                }
            }
        }
    }
}