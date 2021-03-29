using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fixit.Core.DataContracts.Classifications;
using Microsoft.AspNetCore.WebUtilities;

namespace Fixit.Core.Networking.Local.MDM
{
    public class FixMdmHttpClient : IFixMdmHttpClient
    {
        private readonly IHttpClientCore _httpClientCore;

        public FixMdmHttpClient(IHttpClientCore httpClientCore)
        {
            _httpClientCore = httpClientCore ?? throw new ArgumentNullException($"{nameof(FixMdmHttpClient)} expects a value for {nameof(httpClientCore)}... null argument was provided");
        }

        public async Task<IEnumerable<WorkTypeDto>> GetWorkCategoriesAsync(CancellationToken cancellationToken, string categoryName = null, string minTimestampUtc = null, string maxTimestampUtc = null)
        {
            var properties = _httpClientCore.BuildHttpProperties();

            var queryParameters = new Dictionary<string, string>();            
            if (categoryName != null)
            {
                queryParameters.Add("categoryName", categoryName);
            }
            if (minTimestampUtc != null && !string.IsNullOrEmpty(minTimestampUtc))
            {
                queryParameters.Add("minTimestampUtc", minTimestampUtc);
            }
            if (maxTimestampUtc != null && !string.IsNullOrEmpty(maxTimestampUtc))
            {
                queryParameters.Add("maxTimestampUtc", maxTimestampUtc);
            }

            return await _httpClientCore.GetResultAsync<IEnumerable<WorkTypeDto>>(QueryHelpers.AddQueryString($"api/workcategories", queryParameters), cancellationToken, properties);

        }

        public async Task<WorkTypeDto> GetWorkCategoryByIdAsync(Guid workId, CancellationToken cancellationToken)
        {
            var properties = _httpClientCore.BuildHttpProperties();

            return await _httpClientCore.GetResultAsync<WorkTypeDto>($"api/workcategories/{workId}", cancellationToken, properties);
        }


    }
}
