using Fixit.Core.Networking.Local.UMS;
using Fixit.Core.Networking.Local.MDM;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Fixit.Core.Networking.Local.NMS;

namespace Fixit.Core.Networking.Extensions
{
  public static class HttpClientCoreExtension
  {
    public static void AddUmServices(this IServiceCollection services, string serviceEndpoint)
    {
      services.AddTransient<IFixUmsHttpClient, FixUmsHttpClient>(provider =>
      {
          var httpClientCore = new HttpClientCore(new HttpClient(), serviceEndpoint);
          return new FixUmsHttpClient(httpClientCore);
      });
    }

    public static void AddMdmServices(this IServiceCollection services, string serviceEndpoint)
    {
      services.AddTransient<IFixMdmHttpClient, FixMdmHttpClient>(provider =>
      {
          var httpClientCore = new HttpClientCore(new HttpClient(), serviceEndpoint);
          return new FixMdmHttpClient(httpClientCore);
      });
    }

    public static void AddNmsServices(this IServiceCollection services, string serviceEndpoint)
    {
      services.AddTransient<IFixNmsHttpClient, FixNmsHttpClient>(provider =>
      {
        var httpClientCore = new HttpClientCore(new HttpClient(), serviceEndpoint);
        return new FixNmsHttpClient(httpClientCore);
      });
    }
  }
}
