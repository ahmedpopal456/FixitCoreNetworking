using Fixit.Core.DataContracts.Classifications;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Fixit.Core.Networking.Local.MDM
{
    public interface IFixMdmHttpClient
    {
        Task<WorkTypeDto> GetWorkCategoryByIdAsync(Guid workId, CancellationToken cancellationToken);

        Task<IEnumerable<WorkTypeDto>> GetWorkCategoriesAsync(CancellationToken cancellationToken, string categoryName = null, string minTimestampUtc = null, string maxTimestampUtc = null);

    }
}
