


using HotelBooking.Domain.Entities;
using Newtonsoft.Json;

using (var client = new HttpClient())
{
    var url = "https://reqres.in/api/users?page=2";
    var responce = await client.GetAsync(url);
    if (responce.IsSuccessStatusCode)
    {
        var json = await responce.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Data>(json);

        Console.WriteLine(result.Total);
        Console.WriteLine(result.Page);
        Console.WriteLine(result.PerPage);

        foreach (var item in result.UserDatas)
            Console.WriteLine(item.FirstName);
    }
}

