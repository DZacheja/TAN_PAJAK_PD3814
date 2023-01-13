using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientTripsAPI.Models.DTOs.Response;
public class CountriesTripsResponseDto
{
    public string Name { get; set; }
}

public class ClientsTripsResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class GetTripsResponseDto
{
    [JsonProperty(Order = 1)]
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Order")]
    [JsonProperty(Order = 2)]
    public string Description { get; set; }

    [JsonProperty(Order = 3)]
    public DateTime? DateFrom {get; set;}

    [JsonProperty(Order = 4)]
    public DateTime? DateTo {get; set;}

    [JsonProperty(Order = 5)]
    public int? MaxPeople { get; set; }

    [JsonProperty(Order = 6)]
    public IEnumerable<CountriesTripsResponseDto> Countries;

    [JsonProperty(Order = 7)]
    public IEnumerable<ClientsTripsResponseDto> Clients;

}
