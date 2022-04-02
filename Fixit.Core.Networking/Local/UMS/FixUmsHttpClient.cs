using Fixit.Core.DataContracts.Users.Operations.Ratings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fixit.Core.DataContracts.Users.Profile;
using Fixit.Core.DataContracts.Users;

namespace Fixit.Core.Networking.Local.UMS
{
  public class FixUmsHttpClient : IFixUmsHttpClient
  {
    private readonly IHttpClientCore _httpClientCore;

    public FixUmsHttpClient(IHttpClientCore httpClientCore)
    {
      _httpClientCore = httpClientCore ?? throw new ArgumentNullException($"{nameof(FixUmsHttpClient)} expects a value for {nameof(httpClientCore)}... null argument was provided");
    }

    public async Task<List<RatingListResponseDto>> GetRatings(CancellationToken cancellationToken)
    {
      var properties = _httpClientCore.BuildHttpProperties();

      return await _httpClientCore.GetResultAsync<List<RatingListResponseDto>>($"api/users/ratings", cancellationToken, properties);
    }

    public async Task<UserProfileDto> GetUser(Guid userId, CancellationToken cancellationToken)
    {
      var properties = _httpClientCore.BuildHttpProperties();

      return await _httpClientCore.GetResultAsync<UserProfileDto>($"api/{userId}/account/profile", cancellationToken, properties);
    }

    public async Task<List<UserDto>> GetUsers(string entityId, CancellationToken cancellationToken)
    {
      var properties = _httpClientCore.BuildHttpProperties();

      return await _httpClientCore.GetResultAsync<List<UserDto>>($"api/users/{entityId}", cancellationToken, properties);
    }
  }
}
