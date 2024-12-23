﻿using System.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using app.Classes;
using Microsoft.VisualBasic;

namespace app;
using Npgsql;

public class BookingMenu
{
    private NpgsqlDataSource _database;

    public BookingMenu(NpgsqlDataSource database)
    {
        _database = database;
    }
    
    public async Task BookingsMenu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nBooking Menu");
            Console.WriteLine("1. Select User(Account)");
            Console.WriteLine("9. Exit to Main Menu");
            Console.WriteLine("Choose An Option");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await SelectUserAndBook();
                    break;
                case "9":
                    isRunning = false;
                    Console.WriteLine("Return to main menu..");
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please choose 1 or 9.");
                    break;
            }
        }
    }

    private async Task SelectUserAndBook()
    {
        //Select User
        #region Select User
        Console.WriteLine("\nGetting Users(Accounts) from database");
        var users = await GetUsersAsync();

        if (!users.Any())
        {
            Console.WriteLine("No accounts found!");
            return;
        }
        
        Console.WriteLine("\nAvailable Accounts:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Email: {users[i].Email}, Phone: {users[i].Phone} (ID: {users[i].AccountId})");
        }
        Console.WriteLine("Select User by Number:");
        if (!int.TryParse(Console.ReadLine(), out int userIndex) || userIndex < 1 || userIndex > users.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedUser = users[userIndex -1];
        #endregion
        
        //Booking Start
        #region Booking
        Console.WriteLine("\nEnter the booking start date (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine() + " 15:00:00", out DateTime bookingStart) ||
            bookingStart < new DateTime(2024, 12, 1) || bookingStart > new DateTime(2025, 1, 31))
        {
            Console.WriteLine("Invalid Booking Start Date. It must be between 2024-12-01 and 2025-01-31.");
            return;
        }
        
        //Booking End
        Console.WriteLine("Enter the booking end date (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine() + " 10:00:00", out DateTime bookingEnd) || bookingEnd <= bookingStart ||
            bookingEnd > new DateTime(2025, 1, 31))
        {
            Console.WriteLine("Invalid Booking End Date. It must be after Start Date and no later then 2025-01-31.");
            return;
        }
        #endregion

        // Make new Guests
        #region Guests
        Console.Write("How many guests? ");
        if (!int.TryParse(Console.ReadLine(), out int guestCount) || guestCount < 1)
        {
            Console.WriteLine("Invalid number of Guests.");
            return;
        }

        var guests = new List<GuestModel>();
        for (int i = 0; i < guestCount; i++)
        {
            Console.WriteLine($"\nEnter Details for guest {i+1}: ");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? "";
            
            string dateOfBirthInput;
            DateTime dateOfBirth;
            while (true)
            {
                Console.Write("Date of Birth (YYYY-MM-DD): ");
                dateOfBirthInput = Console.ReadLine() ?? string.Empty;

                if (DateTime.TryParseExact(dateOfBirthInput, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out dateOfBirth))
                {
                    break;
                }
                
                Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
            }
            
            guests.Add(
                new GuestModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Booker = selectedUser.AccountId,
                    Date_Of_Birth = dateOfBirthInput
                });
        }
        
        Console.WriteLine("Guests Added: ");
        foreach (var guest in guests)
        {
            Console.WriteLine($"Name: {guest.FirstName} {guest.LastName}, Date of Birth: {guest.Date_Of_Birth}");
        }
        #endregion

        //Select Accommodation
        #region Accommodation
        Console.WriteLine("\nFetching Accommodations..");
        var accommodations = await GetAccommodationsAsync();
        if (!accommodations.Any())
        {
            Console.WriteLine("No accommodations found..");
            return;
        }
        
        Console.WriteLine("\nAvailable Accommodations: ");
        for (int i = 0; i < accommodations.Count; i++)
        {
            Console.WriteLine($"{i +1} {accommodations[i].Name} (ID: {accommodations[i].Id}).");
        }
        Console.WriteLine("Select an Accommodation by Number: ");
        if (!int.TryParse(Console.ReadLine(), out int accommodationIndex) || accommodationIndex < 1 ||
            accommodationIndex > accommodations.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedAccommodation = accommodations[accommodationIndex - 1];
        #endregion

        //Select Room
        #region Select Room
        Console.WriteLine("\nFetching Rooms...");
        var availableRooms = await GetAvailableRoomsAsync(selectedAccommodation.Id);

        for (int i = 0; i < availableRooms.Count; i++)
        {
            var room = availableRooms[i];
            Console.WriteLine($"{i + 1}. Room Details: ");
            Console.WriteLine($"    Accommodation Id: {room.AccommodationId}");
            Console.WriteLine($"    Beds: {room.Beds}");
            Console.WriteLine($"    Size: {room.Size}");
            Console.WriteLine($"    Capacity: {room.Capacity}");
            Console.WriteLine($"    Price: {room.Price}");
        }
        
        Console.WriteLine("\nSelect a Room by number: ");
        if (!int.TryParse(Console.ReadLine(), out int roomIndex) || roomIndex < 1 || roomIndex > availableRooms.Count)
        {
            Console.WriteLine("Inavlid selection.");
            return;
        }

        var selectedRoom = availableRooms[roomIndex - 1];
        Console.WriteLine("\nYou have selected: ");
        Console.WriteLine($"    Accommodation Id: {selectedRoom.AccommodationId}");
        Console.WriteLine($"    Beds: {selectedRoom.Beds}");
        Console.WriteLine($"    Size: {selectedRoom.Size}");
        Console.WriteLine($"    Capacity: {selectedRoom.Capacity}");
        Console.WriteLine($"    Price: {selectedRoom.Price}");
        #endregion

        //Select Extras
        #region Extras
        var extras = await GetExtrasAsync();
        Console.WriteLine("\nChoose Extra: ");
        var selectedExtras = new List<ExtraModel>();

        while (true)
        {
            Console.WriteLine("\nAvailable Extras: ");
            for (int i = 0; i < extras.Count; i++)
            {
                Console.WriteLine($"{i+1}. {extras[i].Name} (Price: {extras[i].Price}");
            }
            Console.WriteLine("Select an Extra by number (or 9 to finish): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number) && number == 9)
            { 
                break;
            }
            if (!int.TryParse(input, out int extraIndex) || extraIndex < 0 || extraIndex > extras.Count)
            {
                Console.WriteLine("Invalid selection!");
                continue;
            }
            var selectedExtra = extras[extraIndex - 1];

            if (selectedExtra.Name == "Full board")
            {
                extras.RemoveAll(e => e.Name == "Breakfast");
                extras.RemoveAll(e => e.Name == "Full board");
                extras.RemoveAll(e => e.Name == "Half Board");
            }
            else if (selectedExtra.Name == "Half board")
            {
                extras.RemoveAll(e => e.Name == "Breakfast");
                extras.RemoveAll(e => e.Name == "Full board");
                extras.RemoveAll(e => e.Name == "Half board");
            }
            else if (selectedExtra.Name == "Breakfast")
            {
                extras.RemoveAll(e => e.Name == "Full board");
                extras.RemoveAll(e => e.Name == "Half board");
            }
            else if (selectedExtra.Name == "ALl-inclusive")
            {
                extras.Clear();
            }
            
            selectedExtras.Add(selectedExtra);
            
            Console.WriteLine("\nYour current Extras: ");
            foreach (var sExtra in selectedExtras)
            {
                    Console.WriteLine($"    - {sExtra.Name} (Price: {sExtra.Price}).");
            }
        }
        #endregion
        
        // Calculate Total Price
        int totalPrice = selectedRoom.Price + selectedExtras.Sum(e => e.Price);
        
        // Insert Booking
        Console.WriteLine($"\nCreating Booking (Your Accommodation: {selectedAccommodation.Name}, Room Number: {selectedRoom.RoomId}, Price: {totalPrice}");
        // Insert the booking
        int bookingId = await InsertBookingAsync(selectedRoom.RoomId, bookingStart, bookingEnd, selectedUser.AccountId,
            totalPrice);

        if (selectedExtras.Any())
        {
            await InsertBookingExtrasAsync(bookingId, selectedExtras);
        }
        foreach (var guest in guests)
        {
            await InsertGuestsAsync(guest.FirstName, guest.LastName, selectedUser.AccountId, guest.Date_Of_Birth);
        }
    }

    private async Task<List<AccountModel>> GetUsersAsync()
    {
        var users = new List<AccountModel>();

        await using (var cmd = _database.CreateCommand(@"SELECT * FROM account"))
        {
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    users.Add(new AccountModel
                    {
                        AccountId = reader.GetInt32(0),
                        Phone = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
            }
        }

        return users;
    }

    private async Task<List<AccommodationModel>> GetAccommodationsAsync()
    {
        var accommodations = new List<AccommodationModel>();

        await using (var cmd = _database.CreateCommand("SELECT * FROM accommodation"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                accommodations.Add(new AccommodationModel
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    DistanceToBeach = reader.GetDouble(2),
                    DistanceToCentrum = reader.GetDouble(3),
                    HasPool = reader.GetBoolean(4),
                    HasEveningEntertainment = reader.GetBoolean(5),
                    HasKidsClub = reader.GetBoolean(6),
                    HasResturant = reader.GetBoolean(7),
                    HasGym = reader.GetBoolean(9),
                    AddressId = reader.GetInt32(8)
                });
            }
        }
            
        return accommodations;
    }

    private async Task<List<RoomModel>> GetAvailableRoomsAsync(int accommodation)
    {
        var rooms = new List<RoomModel>();

        await using (var cmd = _database.CreateCommand(
                         $"SELECT * FROM rooms WHERE accommodation = {accommodation} AND id NOT IN (SELECT room FROM bookings WHERE booking_end >= current_date)"))
        {
            cmd.Parameters.AddWithValue("accommodation", accommodation);
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    rooms.Add(new RoomModel
                    {
                        RoomId = reader.GetInt32(0),
                        Beds = reader.GetInt32(1),
                        Size = reader.GetString(2),
                        Capacity = reader.GetInt32(3),
                        Price = reader.GetInt32(4),
                        AccommodationId = reader.GetInt32(5)
                    });
                }
            }
        }

        return rooms;
    }

    private async Task<List<ExtraModel>> GetExtrasAsync()
    {
        var extras = new List<ExtraModel>();
        
        await using (var cmd = _database.CreateCommand("SELECT * FROM extras"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                extras.Add(new ExtraModel
                {
                    ExtraId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2)
                });
            }
        }

        return extras;
    }

    private async Task<int> InsertBookingAsync( int room, DateTime startDate, DateTime endDate, int account, int totalPrice)
    {
        await using (var cmd = _database.CreateCommand(
                         "INSERT INTO bookings (room, booking_start, booking_end, account, total_price)"
                           +"VALUES ($1 , $2, $3, $4, $5) RETURNING id"))
        {
            cmd.Parameters.AddWithValue(room);
            cmd.Parameters.AddWithValue(startDate);
            cmd.Parameters.AddWithValue(endDate);
            cmd.Parameters.AddWithValue(account);
            cmd.Parameters.AddWithValue(totalPrice);

            await cmd.ExecuteNonQueryAsync();
            
            return (int)await cmd.ExecuteScalarAsync();
        }
    }

    private async Task InsertGuestsAsync(string first_name, string last_name, int booker, string date_of_birth)
    {
        try
        {
            var cmdText =
                "INSERT INTO guests (first_name, last_name, booker, date_of_birth) VALUES ($1, $2, $3, $4)";

            await using (var cmd = _database.CreateCommand(cmdText))
            {
                cmd.Parameters.AddWithValue(first_name);
                cmd.Parameters.AddWithValue(last_name);
                cmd.Parameters.AddWithValue(booker);
                cmd.Parameters.AddWithValue(date_of_birth);

                await cmd.ExecuteNonQueryAsync();
            }
        }
        catch (NpgsqlException npgException)
        {
            Console.WriteLine($"Error: {npgException}");
        }
    }

    private async Task InsertBookingExtrasAsync(int bookingId, List<ExtraModel> selectedExtras)
    {
        foreach (var extra in selectedExtras)
        {
            await using (var cmd = _database.CreateCommand(
                             "INSERT INTO bookingsxextras (booking_id, extras_id) VALUES ($1, $2)"))
            {
                cmd.Parameters.AddWithValue(bookingId);
                cmd.Parameters.AddWithValue(extra.ExtraId);
                await cmd.ExecuteNonQueryAsync();
                
            }
        }
    }
}