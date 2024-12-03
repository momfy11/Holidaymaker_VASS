namespace app;

public class SortByMenu
{
    private bool showMenu = false;
    
    public void Menu()
    {
        showMenu = true;
        Console.WriteLine("Sort Search By:");
        Console.WriteLine("1. Price");
        Console.WriteLine("2. Rating");
        Console.WriteLine("X. Go back");

        while (showMenu)
        {
            var input = Console.ReadLine();
            if (input is not null)
            {
                switch (input)
                {
                    case "1":
                        //return Price
                        Console.WriteLine("Price");
                        showMenu = false;
                        break;
                    case "2":
                        //return Rating
                        Console.WriteLine("Rating");
                        showMenu = false;
                        break;
                    case "x":
                        showMenu = false;
                        break;
                    
                }
            }
        }
    }
}