using Npgsql;
namespace app;

public class CreateUser
{
   
    private readonly NpgsqlDataSource _database;

    public  CreateUser(NpgsqlDataSource database)
    {
        _database = database;
    }
   
    
    public async Task<int> AddAdress()
    {
        string street, street_nr, zipcode, city, country;
        
        Console.WriteLine("Enter street name: or type \"abort\" ");
        while (string.IsNullOrWhiteSpace(street = Console.ReadLine()))
        {
            Console.WriteLine("Street name cannot be empty. Please enter a valid street name:");
        }

        Console.WriteLine("Enter street number:");
        while (string.IsNullOrWhiteSpace(street_nr = Console.ReadLine()))
        {
            Console.WriteLine("Street number cannot be empty. Please enter a valid street number:");
        }

        Console.WriteLine("Enter zipcode:");
        while (string.IsNullOrWhiteSpace(zipcode = Console.ReadLine()))
        {
            Console.WriteLine("Zipcode cannot be empty. Please enter a valid zipcode:");
        }

        Console.WriteLine("Enter city:");
        while (string.IsNullOrWhiteSpace(city = Console.ReadLine()))
        {
            Console.WriteLine("City cannot be empty. Please enter a valid city:");
        }

        Console.WriteLine("Enter country:");
        while (string.IsNullOrWhiteSpace(country = Console.ReadLine()))
        {
            Console.WriteLine("Country cannot be empty. Please enter a valid country:");
        }
        
        await using(var cmd = _database.CreateCommand("INSERT INTO adresses (street, street_nr, zipcode, city, country)" +
                                                                          "VALUES($1, $2, $3, $4, $5) RETURNING id"))
        {
            cmd.Parameters.AddWithValue(street);
            cmd.Parameters.AddWithValue(street_nr);
            cmd.Parameters.AddWithValue(zipcode);
            cmd.Parameters.AddWithValue(city);
            cmd.Parameters.AddWithValue(country);
           
            
            var adressId = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(adressId);
        }
    }
    
    public async Task AddUser( int adress)
    {
        string phone, email;
        
        Console.WriteLine("Enter phone number: ");
        while (string.IsNullOrWhiteSpace(phone = Console.ReadLine()))
        {
            Console.WriteLine("Phone number cannot be empty. Please enter a valid phone number:");
        }

        Console.WriteLine("Enter email address: ");
        while (string.IsNullOrWhiteSpace(email = Console.ReadLine()))
        {
            Console.WriteLine("Email cannot be empty. Please enter a valid email address:");
        }
            
        await using(var cmd = _database.CreateCommand("INSERT INTO account (phone, email, adress)" +
                                                                          "VALUES($1, $2, $3)"))
        {
            cmd.Parameters.AddWithValue(phone);
            cmd.Parameters.AddWithValue(email);
            cmd.Parameters.AddWithValue(adress );
            await cmd.ExecuteNonQueryAsync();
            
            Console.WriteLine("User successfully created.");
        }
    }

    public async Task AddGuest(string first_name, string last_name, string date_of_birth)
    {
        
        Console.WriteLine("Enter First Name: ");
        while (string.IsNullOrWhiteSpace(first_name = Console.ReadLine()))
        {
            Console.WriteLine("First Name cannot be empty. Please enter a valid first name:");
        }
        
        Console.WriteLine("Enter Last Name: ");
        while (string.IsNullOrWhiteSpace(last_name = Console.ReadLine()))
        {
            Console.WriteLine("Last Name cannot be empty. Please enter a valid Last Name:");
        }
        
        Console.WriteLine("Enter the Booker this user is connected to: ");
        if (int.TryParse(Console.ReadLine(), out int booker))
        {
            Console.WriteLine("Successfully added ID.");
        }else
        {
            Console.WriteLine("Invalid ID. Please try again with a valid Number.");
        }

        string inputData;
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Enter a date of birth in the format YYYY-MM-DD: ");
            inputData = Console.ReadLine();
            if (DateTime.TryParseExact(inputData, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None,
                    out DateTime parsedData))
            {
                date_of_birth = parsedData.ToString("yyyy-MM-dd");
                Console.WriteLine($"You entered a valid Date Of Birth: {date_of_birth}");
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid Date format. Please use YYYY-MM-DD (e.g.. 1996-01-09).");
            }
        }
        
        await using(var cmd = _database.CreateCommand("INSERT INTO guests (first_name, last_name, booker, date_of_birth)" +
                                                      "VALUES($1, $2, $3, $4)"))
        {
            cmd.Parameters.AddWithValue(first_name);
            cmd.Parameters.AddWithValue(last_name);
            cmd.Parameters.AddWithValue(booker);
            cmd.Parameters.AddWithValue(date_of_birth);
            await cmd.ExecuteNonQueryAsync();
            
            Console.WriteLine("User successfully created.");
        }
    }
}




