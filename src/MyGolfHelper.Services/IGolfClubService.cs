using MyGolfHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public interface IGolfClubService<TGolfClub, TGolfClubId>
    {
        public Task<IEnumerable<GolfClub>> GetAllGolfClubs();
        public Task<GolfClub> FindGolfClub(TGolfClubId id);
        public Task<int> UpdateGolfClub(TGolfClub golfClub);
        public Task<GolfClub> CreateGolfClub(TGolfClub golfClub);
        public Task<int> DeleteGolfClub(TGolfClubId id);
    }
}
