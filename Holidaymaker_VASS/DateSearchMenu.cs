namespace app;

public class DateSearchMenu
{
    private bool showMenu = false;
    private string[] months = new[] { "December 2024", "January 2025" };

    public DateTime startDate;
    public DateTime endDate;
    public void Menu()
    {
        showMenu = true;
        while (showMenu)
        {
            Console.WriteLine($"Choose month:");
            Console.WriteLine($"1. " + months[0]);
            Console.WriteLine($"2. " + months[1]);
            Console.WriteLine("E. Exit");
            
            var inputMonth = Console.ReadLine();
            if (inputMonth is "1" or "2")
            {
                Console.WriteLine("Enter day of month:");
                
                var inputDay = Console.ReadLine();
                if (Int32.TryParse(inputDay, out int day))
                {
                    if(1 <= day && day <= 31)
                    {
                        if (DateTime.TryParse($"{day} {months[Int32.Parse(inputMonth) - 1]} 13:00", out var date))
                        {
                            startDate = date;
                        }
                        else
                        {
                            InvalidInput();
                        }
                        
                        Console.WriteLine("Enter length of stay:");
                        var inputStay = Console.ReadLine();
                        if (inputStay is not null && Int32.TryParse(inputStay, out int stay))
                        {
                            endDate = date.Add(TimeSpan.FromDays(stay) + TimeSpan.FromHours(-2));
                            
                            Console.WriteLine("Arrival Date: " + startDate);
                            Console.WriteLine("Leave Date: " + endDate);
                            Console.ReadLine();
                            //Go back to Filter Menu
                            showMenu = false;
                        }
                        else
                        {
                            InvalidInput();
                        }
                    }
                    else
                    {
                        InvalidInput();
                    }
                }
                else
                {
                    InvalidInput();
                }
            }
            else if (inputMonth is "e")
            {
                showMenu = false;
            }
            else
            {
                InvalidInput();
            }
        }
    }

    private void InvalidInput()
    {
        Console.WriteLine("Invalid Input");
        showMenu = false;
        Menu();
    }
}