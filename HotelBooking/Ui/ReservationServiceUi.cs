using HotelBooking.Domain.Entities;
using HotelBooking.Service.Services;
using System;
using System.Threading.Tasks;

public class ReservationServiceUi
{
    private static readonly ReservationService reservationService = new ReservationService();

    public async void CreatedReservation()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Reservation Manager!");
            Console.WriteLine("===================================");
            Console.WriteLine("1. View all reservations");
            Console.WriteLine("2. View a reservation");
            Console.WriteLine("3. Add a reservation");
            Console.WriteLine("4. Update a reservation");
            Console.WriteLine("5. Delete a reservation");
            Console.WriteLine("6. Exit");
            Console.WriteLine("===================================");

            Console.Write("Enter a number to perform an action: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await ViewAllReservations();
                    break;
                case "2":
                    await ViewReservation();
                    break;
                case "3":
                    await AddReservation();
                    break;
                case "4":
                    await UpdateReservation();
                    break;
                case "5":
                    await DeleteReservation();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static async Task ViewAllReservations()
    {
        Console.Clear();
        var response = await reservationService.GetAllAsync(x => true);
        if (response.StatusCode == 200 && response.Value.Count > 0)
        {
            Console.WriteLine("All Reservations:");
            Console.WriteLine("==================");
            foreach (var reservation in response.Value)
            {
                Console.WriteLine($"ID: {reservation.Id}");
                Console.WriteLine($"Name: {reservation.FirstName} {reservation.LastName}");
                Console.WriteLine($"Check-In: {reservation.ChackIn:MM/dd/yyyy}");
                Console.WriteLine($"Check-Out: {reservation.ChackOut:MM/dd/yyyy}");
                Console.WriteLine($"Payment: {reservation.Payment:C}");
                Console.WriteLine($"Payment Type: {reservation.PaymentType}");
                Console.WriteLine($"Status: {reservation.Status}");
                Console.WriteLine("==================");
            }
        }
        else
        {
            Console.WriteLine("No reservations found.");
        }
    }

    private static async Task ViewReservation()
    {
        Console.Clear();
        Console.Write("Enter a reservation ID: ");
        var input = Console.ReadLine();
        if (long.TryParse(input, out long id))
        {
            var response = await reservationService.GetByIdAsync(id);
            if (response.StatusCode == 200 && response.Value != null)
            {
                var reservation = response.Value;
                Console.WriteLine($"ID: {reservation.Id}");
                Console.WriteLine($"Name: {reservation.FirstName} {reservation.LastName}");
                Console.WriteLine($"Check-In: {reservation.ChackIn:MM/dd/yyyy}");
                Console.WriteLine($"Check-Out: {reservation.ChackOut:MM/dd/yyyy}");
                Console.WriteLine($"Payment: {reservation.Payment:C}");
                Console.WriteLine($"Payment Type: {reservation.PaymentType}");
                Console.WriteLine($"Status: {reservation.Status}");
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
    public async Task AddReservationAsync(Reservation reservation)
    {
        var response = await reservationService.CreateAsync(reservation);

        if (response.StatusCode == 200)
        {
            Console.WriteLine($"Successfully added reservation with ID: {response.Value.Id}");
        }
        else
        {
            Console.WriteLine($"Error: {response.Message}");
        }
    }
