using Quartz;
using RestSharp;

namespace GMRService;

public class Job : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        throw new NotImplementedException();
    }

    void HttpPost(string baseUrl, string relativeUrl, RestRequest request)
    {
        var options = new RestClientOptions(baseUrl)
        {
            MaxTimeout = -1,
            UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
        };
        var client = new RestClient(options);
        request.AddHeader("accept", "*/*");
        request.AddHeader("Content-Type", "application/json, text/plain, */*");
    }
}