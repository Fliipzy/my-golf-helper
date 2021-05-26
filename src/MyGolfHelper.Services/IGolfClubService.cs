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
        public Task<IEnumerable<GolfClub>> GetAllGolfClubsAsync();
        public Task<GolfClub> FindGolfClubAsync(TGolfClubId id);
        public Task<int> UpdateGolfClubAsync(TGolfClub golfClub);
        public Task<bool> CreateGolfClubAsync(TGolfClub golfClub);
        public Task<int> DeleteGolfClubAsync(TGolfClubId id);
    }
}
