using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities;

public class Data
{

    [JsonProperty("page")]
    public int Page{ get; set; }
    [JsonProperty("per_page")]
    public int PerPage { get; set; }
    [JsonProperty("total")]
    public int Total { get; set; }
    [JsonProperty("total_page")]
    public int TotalPage { get; set; }
    [JsonProperty("data")]
    public List<UserData> UserDatas { get; set; }
}
