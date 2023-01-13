using ClientTripsAPI.Models;
using ClientTripsAPI.Models.DTOs.Response;
using ClientTripsAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTripsAPI.Services;
public class SqlServerDbService : IDatabseService
{
    private TripsContext _context;
    public SqlServerDbService(TripsContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteClient(int clientId)
    {
        var res = await _context.ClientTrips.FirstOrDefaultAsync(t => t.IdClient == clientId);

        if (res != null)
            return false;

        Client clientToDelete = new Client { IdClient = clientId };

        _context.Clients.Attach(clientToDelete);
        _context.Entry(clientToDelete).State = EntityState.Deleted;

        var results = await _context.SaveChangesAsync();
        return results > 0;
    }

    public async Task<IEnumerable<GetTripsResponseDto>> GetTrips()
    {
        var results = _context.Trips.OrderByDescending(t => t.DateFrom)
            .Include(e => e.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
            .Include(e => e.IdCountries).Select(rec => new GetTripsResponseDto()
            {
                Name = rec.Name,
                Description = rec.Description,
                DateFrom = rec.DateFrom,
                DateTo = rec.DateTo,
                MaxPeople = rec.MaxPeople,
                Clients = rec.ClientTrips.Select(r => new ClientsTripsResponseDto()
                {
                    FirstName = r.IdClientNavigation.FirstName,
                    LastName = r.IdClientNavigation.LastName
                }).ToList(),
                Countries = rec.IdCountries.Select(r => new CountriesTripsResponseDto()
                {
                    Name = r.Name
                }).ToList()

            }).ToList(); 
        return results;
    }
}
