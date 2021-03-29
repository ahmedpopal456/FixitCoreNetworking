using System.Threading;
using System.Threading.Tasks;
using Fixit.Core.DataContracts;
using Fixit.Core.DataContracts.Notifications.Operations;

namespace Fixit.Core.Networking.Local.NMS
{
  public interface IFixNmsHttpClient
  {
    Task<OperationStatus> PostNotification(EnqueueNotificationRequestDto enqueueNotificationRequestDto, CancellationToken cancellationToken);
  }
}
