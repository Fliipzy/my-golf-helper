using MyGolfHelper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public class GolfClubService : IGolfClubService<GolfClub, long>
    {
        public Task<GolfClub> CreateGolfClub(GolfClub golfClub)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteGolfClub(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<GolfClub> FindGolfClub(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GolfClub>> GetAllGolfClubs()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> UpdateGolfClub(GolfClub golfClub)
        {
            throw new System.NotImplementedException();
        }
    }
}