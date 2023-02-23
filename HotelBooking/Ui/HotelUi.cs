using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Presentation.Ui
{
    public class HotelUi
    {
        HotelService hotelservice = new HotelService();
        public async void CreatedHotel()
        {
            HotelCreationDto hotel = new HotelCreationDto();
            first:
            while (true)
            {
                Console.WriteLine("1-Create Hotel: ");
                Console.WriteLine("2-Delate Hotel : ");
                Console.WriteLine("3-GetByID Hotel: ");
                Console.WriteLine("4-Update Hotel: ");
                Console.WriteLine("5-GetAll Hotel: ");
                Console.WriteLine("0-Exit");
                int num = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(num)
                {
                    case 1:
                        Console.WriteLine("Mehmonxona nomi:");
                        hotel.Name = Console.ReadLine();
                        Console.WriteLine("Mehmonxona qaysi davlatda joylashgan:");
                        hotel.Country = Console.ReadLine();
                        Console.WriteLine("Mehmonxona qaysi shaxarda joylashgan:");
                        hotel.City = Console.ReadLine();
                        Console.WriteLine("Mehmonxona ko'chasi");
                        hotel.Street = Console.ReadLine();
                        Console.WriteLine("Mehmonxona telfon nomeri :");
                        hotel.Phone = Console.ReadLine();
                        await hotelservice.CreateAsync(hotel);
                        goto first;
                    case 2:
                        Predicate<Hotel> predicate = delegate (Hotel s) { return s.Id>0; };
                        hotelservice.GetAllAsync(predicate);
                        Console.WriteLine("Id kirit");
                        long id = long.Parse(Console.ReadLine());
                        await hotelservice.DeleteAsync(id);
                        break;
                    case 3:
                        Console.WriteLine("Id kirit");
                        long idd = long.Parse(Console.ReadLine());
                        hotelservice.DeleteAsync(idd);
                        break;
                    case 4:
                        Console.WriteLine("Id kirit");
                        long iddd = long.Parse(Console.ReadLine());
                        Console.WriteLine("Mehmonxona nomi:");
                        hotel.Name = Console.ReadLine();
                        Console.WriteLine("Mehmonxona qaysi davlatda joylashgan:");
                        hotel.Country = Console.ReadLine();
                        Console.WriteLine("Mehmonxona qaysi shaxarda joylashgan:");
                        hotel.City = Console.ReadLine();
                        Console.WriteLine("Mehmonxona ko'chasi");
                        hotel.Street = Console.ReadLine();
                        Console.WriteLine("Mehmonxona telfon nomeri :");
                        hotel.Phone = Console.ReadLine();
                        await hotelservice.UpdateAsync(iddd,hotel);
                        break;
                    case 5:
                        var getAllResponse = await hotelservice.GetAllAsync(hotel => true);

                        Console.WriteLine("Hotels:");

                        foreach (var i in getAllResponse.Value)
                        {
                            Console.WriteLine($" Name: {hotel.Name}\n Cauntry {hotel.Country}\n City {hotel.City} \n Sreet {hotel.Street} ");
                        }

                        break;
                    case 0:
                        System.Environment.Exit(0);
                        Console.WriteLine("******Dastur to'xtatildi********");
                        break;


                }
            }
        }
    }
}
