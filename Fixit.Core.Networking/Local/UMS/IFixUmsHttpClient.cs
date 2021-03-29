using Fixit.Core.DataContracts.Users;
using Fixit.Core.DataContracts.Users.Profile;
using Fixit.Core.DataContracts.Users.Operations.Ratings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fixit.Core.Networking.Local.UMS
{
    public interface IFixUmsHttpClient
    {
        Task<List<RatingListResponseDto>> GetRatings(CancellationToken cancellationToken);

        Task<List<UserDto>> GetUsers(string entityId, CancellationToken cancellationToken);

        Task<UserProfileDto> GetUser(Guid userId, CancellationToken cancellationToken);

    }
}
