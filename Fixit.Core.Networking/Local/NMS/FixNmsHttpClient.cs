using System;
using System.Threading;
using System.Threading.Tasks;
using Fixit.Core.DataContracts;
using Fixit.Core.DataContracts.Notifications.Operations;

namespace Fixit.Core.Networking.Local.NMS
{
  public class FixNmsHttpClient : IFixNmsHttpClient
  {
    private readonly IHttpClientCore _httpClientCore;

    public FixNmsHttpClient(IHttpClientCore httpClientCore)
    {
      _httpClientCore = httpClientCore ?? throw new ArgumentNullException($"{nameof(FixNmsHttpClient)} expects a value for {nameof(httpClientCore)}... null argument was provided");
    }

    public async Task<OperationStatus> PostNotification(EnqueueNotificationRequestDto enqueueNotificationRequestDto, CancellationToken cancellationToken)
    {
      return await _httpClientCore.PostAsync<OperationStatus>($"api/Notifications", enqueueNotificationRequestDto, cancellationToken);
    }
  }
}
