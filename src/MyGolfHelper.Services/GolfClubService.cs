using MyGolfHelper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public class GolfClubService : IGolfClubService<GolfClub, long>
    {
        public Task<bool> CreateGolfClubAsync(GolfClub golfClub)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteGolfClubAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<GolfClub> FindGolfClubAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GolfClub>> GetAllGolfClubsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateGolfClubAsync(GolfClub golfClub)
        {
            throw new System.NotImplementedException();
        }
    }
}