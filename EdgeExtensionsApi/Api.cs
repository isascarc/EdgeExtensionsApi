using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

namespace EdgeExtensionsApi;

public static class Extensions
{
    private static readonly string baseUrl = "https://microsoftedge.microsoft.com/";
    private static readonly string getExtensionDetailUrl = $"{baseUrl}addons/getproductdetailsbycrxid";
    private static readonly string getSuggestionsUrl = $"{baseUrl}edgestorewebautocomplete/v1/search?hl=en-US&gl=US";
    private static readonly string searchUrl = $"{baseUrl}addons/v1/getfilteredorderedsearch?hl=en-US&gl=US&filteredCategories=Edge-Extensions&filteredAddon=0&sortBy=Relevance&pgNo=1";

    private static readonly HttpClient client = new();


    public async static Task<JsonNode> GetExtensionDetail(string crxId)
    {
        return await GetData($"{getExtensionDetailUrl}/{crxId}");
    }

    public async static Task<JsonNode> GetSuggestions(string query)
    {
        ArgumentException.ThrowIfNullOrEmpty(query);

        return await GetData($"{getSuggestionsUrl}&q={query}");
    }

    public async static Task<JsonNode> Search(string query)
    {
        ArgumentException.ThrowIfNullOrEmpty(query);

        return await GetData($"{searchUrl}&Query={query}");
    }


    private async static Task<JsonNode> GetData(string uriString)
    {
        var url = new Uri(uriString);

        HttpRequestMessage request = new(HttpMethod.Get, url.OriginalString);
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("Host", url.Host);

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var res = await response.Content.ReadAsStringAsync();
        return JsonNode.Parse(res);
    }
}