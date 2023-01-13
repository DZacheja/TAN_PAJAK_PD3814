using ClientTripsAPI.Models;
using ClientTripsAPI.Models.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTripsAPI.Services.Interfaces;
public interface IDatabseService
{
    Task<bool> DeleteClient(int clientId);
    Task<IEnumerable<GetTripsResponseDto>> GetTrips();
}
