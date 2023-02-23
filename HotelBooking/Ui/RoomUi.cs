using HotelBooking.Domain.Entities;
using HotelBooking.Service.DTOs;
using HotelBooking.Service.Interfaces;
using HotelBooking.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Presentation.Ui
{
    public class RoomUi
    {
        RoomService roomService = new RoomService();
        public async void CreatedRoom()
        {
            RoomCreationDto room = new RoomCreationDto();
            while(true)
            {
                Console.WriteLine("1-Create Room: ");
                Console.WriteLine("2-Delate Room : ");
                Console.WriteLine("3-GetByID Room: ");
                Console.WriteLine("4-Update Room: ");
                Console.WriteLine("5-GetAll Room: ");
                Console.WriteLine("0-Exit");
                int num = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(num)
                {
                    case 1:
                        Console.WriteLine("Xonalar soni:");
                        room.Capacity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Xona narxi:");
                        room.Price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Xona haqida malumot:");
                        room.Desription = Console.ReadLine();
                        Console.WriteLine("Qanday xona");
                        room.Type = Console.ReadLine();
                        Console.WriteLine("Xona xolati :");
                        room.Status = Console.ReadLine();
                        await roomService.CreateAsync(room);
                        break;

                }
            }
        }
    }
}
