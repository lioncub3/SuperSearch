using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch.Models;
using SuperSearch.Models;

namespace SuperSearch.Services
{
    public class NewsSearchSamples
    {
        public static List<NewsObject> NewsSearchWithFilters(string subscriptionKey, string query)
        {
            List<NewsObject> news = new List<NewsObject>();

            var client = new NewsSearchClient(new ApiKeyServiceClientCredentials(subscriptionKey));

            try
            {
                var newsResults = client.News.SearchAsync(query: query, market: "en-us", freshness: "Week", sortBy: "Date").Result;
                //Console.WriteLine("Search most recent news for query with freshness and sortBy");

                if (newsResults == null)
                {
                    //Console.WriteLine("Didn't see any news result data..");
                }
                else
                {
                    if (newsResults.Value.Count > 0)
                    {
                        foreach (var firstNewsResult in newsResults.Value)
                        {
                            news.Add(new NewsObject() { Name = firstNewsResult.Name, Url = firstNewsResult.Url });
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Couldn't find news results!");
                    }
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Encountered exception. " + ex.Message);
            }

            return news;
        }
    }
}
