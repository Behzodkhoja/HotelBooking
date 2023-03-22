using HotelBooking.Domain.Entities;
using HotelBooking.Service.Helpers;
using HotelBooking.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Service.Services
{
    public class UserDataService : IUserDataService
    {
        
        public async Task<Response<UserData>> SearchUserAsync(string type)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync($"https://arbeitnow.com/api/job-board-api{type}");
            string jsonString = await message.Content.ReadAsStringAsync();

            try
            {
                var entity = JsonConvert.DeserializeObject<UserData>(jsonString);
                return new Response<UserData>()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Value = entity
                };
            }
            catch (Exception ex)
            {
                return new Response<UserData>()
                {
                    StatusCode = 200,
                    Message = ex.Message,
                    Value = null
                };
            }
        }
    }
}
