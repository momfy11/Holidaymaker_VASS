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
            cmd.Parameters.AddWithValue(adress);
            await cmd.ExecuteNonQueryAsync();
            
            Console.WriteLine("User successfully created.");
        }
    }
    
    
    
public async void RemoveBooking(int id)
    {
        await using (var cmd = _database.CreateCommand("DELETE FROM bookings WHERE id = $1"))
        {
            cmd.Parameters.AddWithValue(id);
            int result = await cmd.ExecuteNonQueryAsync();
            Console.WriteLine(result);
        }
    }
    
}




/*


NEDAN KOD BEHÖVER SÄTTAS IN I MENYN FÖR ATT SKAPA ANVÄNDARE

    var createUser = new CreateUser(database.Connection());
    
    int addressId = await createUser.AddAdress();
    await createUser.AddUser(addressId);

*/

