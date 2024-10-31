using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommAI.Data;
using CommAI.Models;
using HtmlAgilityPack;
using System.Text;
using System.Text.Json;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Newtonsoft.Json.Linq;
using System.Collections;
using SerpApi;

namespace CommAI.Controllers
{
    public class CommercialScriptInsightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommercialScriptInsightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommercialScriptInsights
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommercialScriptInsights.Include(c => c.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CommercialScriptInsights/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptInsights = await _context.CommercialScriptInsights
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialScriptInsights == null)
            {
                return NotFound();
            }

            return View(commercialScriptInsights);
        }

        // GET: CommercialScriptInsights/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: CommercialScriptInsights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName,ProductOrService,ProductOrServiceName,ProductOrServiceDescription,Promise,ConsumerInsights,Reason,ReasonToBelieve,Story,Script,Duration,AgeGroup,GenderGroup,IdentityUserId")] CommercialScriptInsights commercialScriptInsights)
        {
            if (ModelState.IsValid)
            {
                commercialScriptInsights.Id = Guid.NewGuid();
                _context.Add(commercialScriptInsights);

                int isSaved = await _context.SaveChangesAsync();

                if (isSaved == 1)
                {
                    CommercialScript commercialScript = new CommercialScript();
                    commercialScript.Id = Guid.NewGuid();
                    commercialScript.BrandName = commercialScriptInsights.BrandName;
                    commercialScript.ProductOrService = commercialScriptInsights.ProductOrService;
                    commercialScript.ProductOrServiceName = commercialScriptInsights.ProductOrServiceName;
                    commercialScript.ProductOrServiceDescription = commercialScriptInsights.ProductOrServiceDescription;
                    commercialScript.Promise = commercialScriptInsights.Promise;
                    commercialScript.ConsumerInsights = commercialScriptInsights.ConsumerInsights;
                    commercialScript.Reason = commercialScriptInsights.Reason;
                    commercialScript.ReasonToBelieve = commercialScriptInsights.ReasonToBelieve;
                    commercialScript.Story = commercialScriptInsights.Story;
                    commercialScript.Script = commercialScriptInsights.Script;
                    commercialScript.Duration = commercialScriptInsights.Duration;
                    commercialScript.AgeGroup = commercialScriptInsights.AgeGroup;
                    commercialScript.GenderGroup = commercialScriptInsights.GenderGroup;
                    commercialScript.CommercialScriptInsightsId = commercialScriptInsights.Id;
                    commercialScript.NewsCollection = await ScrapeAdaDeranaOnline();

                    bool isAllDone = await EnhancementOperation(commercialScript);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", commercialScriptInsights.IdentityUserId);
            return View(commercialScriptInsights);
        }

        // GET: CommercialScriptInsights/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptInsights = await _context.CommercialScriptInsights.FindAsync(id);
            if (commercialScriptInsights == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", commercialScriptInsights.IdentityUserId);
            return View(commercialScriptInsights);
        }

        // POST: CommercialScriptInsights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BrandName,ProductOrService,ProductOrServiceName,ProductOrServiceDescription,Promise,ConsumerInsights,Reason,ReasonToBelieve,Story,Script,Duration,AgeGroup,GenderGroup,IdentityUserId")] CommercialScriptInsights commercialScriptInsights)
        {
            if (id != commercialScriptInsights.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CommercialScript? commercialScript = await _context.CommercialScript.FirstOrDefaultAsync(c => c.CommercialScriptInsightsId == id);
                    commercialScript.BrandName = commercialScriptInsights.BrandName;
                    commercialScript.ProductOrService = commercialScriptInsights.ProductOrService;
                    commercialScript.ProductOrServiceName = commercialScriptInsights.ProductOrServiceName;
                    commercialScript.ProductOrServiceDescription = commercialScriptInsights.ProductOrServiceDescription;
                    commercialScript.Promise = commercialScriptInsights.Promise;
                    commercialScript.ConsumerInsights = commercialScriptInsights.ConsumerInsights;
                    commercialScript.Reason = commercialScriptInsights.Reason;
                    commercialScript.ReasonToBelieve = commercialScriptInsights.ReasonToBelieve;
                    commercialScript.Story = commercialScriptInsights.Story;
                    commercialScript.Script = commercialScriptInsights.Script;
                    commercialScript.Duration = commercialScriptInsights.Duration;
                    commercialScript.AgeGroup = commercialScriptInsights.AgeGroup;
                    commercialScript.GenderGroup = commercialScriptInsights.GenderGroup;
                    commercialScript.NewsCollection = await ScrapeAdaDeranaOnline();

                    _context.Update(commercialScriptInsights);
                    await _context.SaveChangesAsync();

                    CommercialScriptSuggestion? commercialScriptSuggestion = await _context.CommercialScriptSuggestion.FirstOrDefaultAsync(c => c.CommercialScriptId == commercialScript.Id);
                    CommercialScriptEnhanced? commercialScriptEnhanced = await _context.CommercialScriptEnhanced.FirstOrDefaultAsync(c => c.CommercialScriptId == commercialScript.Id);

                    bool IsAllDone = await EnhancementOperation(commercialScript, commercialScriptSuggestion!.Id, commercialScriptEnhanced!.Id);

                    if (IsAllDone == false)
                    {
                        return RedirectToAction(nameof(Edit));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommercialScriptInsightsExists(commercialScriptInsights.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", commercialScriptInsights.IdentityUserId);
            return View(commercialScriptInsights);
        }

        // GET: CommercialScriptInsights/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialScriptInsights = await _context.CommercialScriptInsights
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialScriptInsights == null)
            {
                return NotFound();
            }

            return View(commercialScriptInsights);
        }

        // POST: CommercialScriptInsights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var commercialScriptInsights = await _context.CommercialScriptInsights.FindAsync(id);
            if (commercialScriptInsights != null)
            {
                _context.CommercialScriptInsights.Remove(commercialScriptInsights);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommercialScriptInsightsExists(Guid id)
        {
            return _context.CommercialScriptInsights.Any(e => e.Id == id);
        }

        private async Task<bool> EnhancementOperation(CommercialScript commercialScript, Guid commercialScriptSuggestionId = default, Guid commercialScriptEnhancedId = default)
        {
            StringBuilder newsContent = new StringBuilder();
            newsContent.Append(commercialScript.NewsCollection).Append("\n");
            newsContent.AppendLine("Using these news you should create a attractive memorable creative content to advertise for ").Append(commercialScript.ProductOrServiceName).Append(" and it's ");
            newsContent.Append("description is ").Append(commercialScript.ProductOrServiceDescription).Append(".");
            newsContent.Append(" This is the new ").Append(commercialScript.ProductOrService).Append(" of ").Append(commercialScript.BrandName).Append(".");
            newsContent.Append(" You should write content for ").Append(commercialScript.AgeGroup).Append(" age group");

            commercialScript.NewsCreativeContent = await GenerateWithGemini(newsContent.ToString());

            StringBuilder newsCreativeContentBasedNews = new StringBuilder();
            newsCreativeContentBasedNews.Append("This is the news collection.").Append("\n");
            newsCreativeContentBasedNews.AppendLine(commercialScript.NewsCollection);
            newsCreativeContentBasedNews.AppendLine(" and this is the creative content");
            newsCreativeContentBasedNews.AppendLine(commercialScript.NewsCreativeContent);
            newsCreativeContentBasedNews.AppendLine("Now tell me what is the news best suited with this content. give me that news with the date. Remember! you should give only based news with date! that's enough!");

            commercialScript.NewsCreativeContentBasedNews = await GenerateWithGemini(newsCreativeContentBasedNews.ToString());

            commercialScript.CurrentTrendingQueries = commercialScript.BrandName!;
            StringBuilder currentTrendingQueries = new StringBuilder();
            currentTrendingQueries.Append(commercialScript.CurrentTrendingQueries)
                .AppendLine()
                .AppendLine("Using these queries, you should write creative content around with 50 - 60 words. Remember! You should avoid using all of person's names, region names and bad words from these queries!");

            commercialScript.CurrentTrendingQueriesCreativeContent = await GenerateWithGemini(currentTrendingQueries.ToString());

            commercialScript.BrandTrendingQueries = commercialScript.BrandName!;
            StringBuilder brandTrendingQueries = new StringBuilder();
            currentTrendingQueries.Append(commercialScript.BrandTrendingQueries)
                .AppendLine()
                .AppendLine("Using these queries, you should write creative content around with 50 - 60 words. Remember! You should avoid using all of person's names, region names and bad words from these queries!");

            commercialScript.BrandTrendingQueriesCreativeContent = await GenerateWithGemini(brandTrendingQueries.ToString());

            commercialScript.TrendingYouTubeVideoTitleCollection = commercialScript.BrandName!;

            StringBuilder trendingTitles = new StringBuilder();
            trendingTitles.Append(commercialScript.TrendingYouTubeVideoTitleCollection).Append("\n")
            .AppendLine("Using these titles, you should write creative content around with 50 - 60 words.");

            commercialScript.TrendingYouTubeVideoTitleCreativeContent = await GenerateWithGemini(trendingTitles.ToString());

            StringBuilder weakPoints = new StringBuilder();
            weakPoints.Append("This is story").AppendLine();
            weakPoints.Append(commercialScript.Story).AppendLine().AppendLine();
            weakPoints.Append("This is script").AppendLine();
            weakPoints.Append(commercialScript.Script).AppendLine().AppendLine();
            weakPoints.Append("This is promise").AppendLine();
            weakPoints.Append(commercialScript.Promise).AppendLine().AppendLine();
            weakPoints.Append("Now, analyzing this story, promise and it's tv commercial script you should identifying weak points of this tv commercial script. Give me weak points with comma separated.");
            weakPoints.AppendLine("Remember! target age group is ").Append(commercialScript.AgeGroup);

            commercialScript.WeakPoints = await GenerateWithGemini(weakPoints.ToString());

            StringBuilder contents = new StringBuilder();
            contents.Append("This is 1st creative content").AppendLine().AppendLine();
            contents.Append(commercialScript.NewsCreativeContent).AppendLine().AppendLine();
            contents.Append("This is 2nd creative content").AppendLine().AppendLine();
            contents.Append(commercialScript.CurrentTrendingQueriesCreativeContent).AppendLine().AppendLine();
            contents.Append("This is 3rd creative content").AppendLine().AppendLine();
            contents.Append(commercialScript.BrandTrendingQueriesCreativeContent).AppendLine().AppendLine();
            contents.Append("This is 4th creative content").AppendLine().AppendLine();
            contents.Append(commercialScript.TrendingYouTubeVideoTitleCreativeContent).AppendLine().AppendLine();

            StringBuilder idea = new StringBuilder();
            idea.Append("Using these contents ").AppendLine(contents.ToString()).AppendLine();
            idea.Append(" , generate attractive creative memorable advertising idea for TV commercial for ").Append(commercialScript.AgeGroup).Append(" age group");

            commercialScript.AdvertisingIdea = await GenerateWithGemini(idea.ToString());

            StringBuilder suggestions = new StringBuilder();
            suggestions.Append("This is story ").AppendLine(commercialScript.Story).AppendLine().AppendLine();
            suggestions.Append("This is script ").AppendLine(commercialScript.Script).AppendLine().AppendLine();
            suggestions.Append("These are identified weak points ").AppendLine(commercialScript.WeakPoints).AppendLine().AppendLine();
            suggestions.Append("Now, provides suggestions for improve this tv commercial script. give suggestions with comma separated. Remember! you should give only suggestions with comma separated. No any other sentences.");

            commercialScript.Suggestions = await GenerateWithGemini(suggestions.ToString());

            StringBuilder suggestionsCount = new StringBuilder();
            suggestions.Append(commercialScript.Suggestions).AppendLine().AppendLine("How many number of suggestions? do not give any English words, give suggestions count as just integer value. That's enough!");

            commercialScript.SuggestionsCount = await GenerateWithGemini(suggestions.ToString());

            StringBuilder scriptDemo = new StringBuilder();
            scriptDemo.Append("This is Advertising idea").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.AdvertisingIdea).AppendLine().AppendLine();
            scriptDemo.Append("This is story").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.Story).AppendLine().AppendLine();
            scriptDemo.Append("This is script").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.Script).AppendLine().AppendLine();
            scriptDemo.Append("Using this advertising idea and story, you should enhanced this tv commercial script. Give enhanced tv commercial script").AppendLine().AppendLine();
            scriptDemo.Append("Remember! the script duration is ").Append(commercialScript.Duration).Append(" seconds.");

            string? scriptDemoFirst = await GenerateWithGemini(scriptDemo.ToString());

            scriptDemo.Clear();
            scriptDemo.Append("This is tv commercial script").AppendLine().AppendLine();
            scriptDemo.Append(scriptDemoFirst).AppendLine().AppendLine();
            scriptDemo.Append("These are suggestions").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.Suggestions).AppendLine().AppendLine();
            scriptDemo.Append("Now, enhance this script using these suggestions and reason. Give enhanced tv commercial script.");

            string? scriptDemoSecond = await GenerateWithGemini(scriptDemo.ToString());

            scriptDemo.Clear();
            scriptDemo.Append("This is tv commercial script").AppendLine().AppendLine();
            scriptDemo.Append(scriptDemoSecond).AppendLine().AppendLine();
            scriptDemo.Append("These are consumer insights").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.ConsumerInsights).AppendLine().AppendLine();
            scriptDemo.Append("and the emotional tone should be ");
            scriptDemo.Append(commercialScript.EmotionalTone).AppendLine().AppendLine();
            scriptDemo.Append("Now, enhance this script related to this consumer insights and emotional tone. Give enhanced tv commercial script.");

            string? scriptDemoThird = await GenerateWithGemini(scriptDemo.ToString());
            scriptDemo.Clear();
            scriptDemo.Append("This is tv commercial script").AppendLine().AppendLine();
            scriptDemo.Append(scriptDemoThird).AppendLine().AppendLine();
            scriptDemo.Append("This is promise about the ").Append(commercialScript.ProductOrService).AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.Promise).AppendLine().AppendLine();
            scriptDemo.Append("This is reason").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.Reason).AppendLine().AppendLine();
            scriptDemo.Append(" and this is reason to believe").AppendLine().AppendLine();
            scriptDemo.Append(commercialScript.ReasonToBelieve).AppendLine().AppendLine();
            scriptDemo.Append("and the brand message clarity should be ");
            scriptDemo.Append(commercialScript.BrandMessagingClarity).AppendLine().AppendLine();
            scriptDemo.Append("Now, enhance this script related to this brand message clarity. Give enhanced tv commercial script.");

            string? scriptDemoFourth = await GenerateWithGemini(scriptDemo.ToString());

            scriptDemo.Clear();
            scriptDemo.Append("This is tv commercial script").AppendLine().AppendLine();
            scriptDemo.Append(scriptDemoFourth).AppendLine().AppendLine();
            scriptDemo.Append("and also it should reflect ").Append(commercialScript.NumberOfKeyMessages).Append(" number of key messages");
            scriptDemo.Append("Now, enhance this script. Give enhanced tv commercial script. Remember! you should give only enhanced script only! No any other sentences!");

            string? scriptDemoFifth = await GenerateWithGemini(scriptDemo.ToString());
            
            commercialScript.EnhancedScript = scriptDemoFifth;

            StringBuilder enhancedScriptTagLine = new StringBuilder();
            enhancedScriptTagLine.Append("This is tv commercial script").AppendLine().AppendLine();
            enhancedScriptTagLine.Append(commercialScript.EnhancedScript).AppendLine().AppendLine();
            enhancedScriptTagLine.Append("Now, give memorable attractive tagline");

            commercialScript.EnhancedScriptTagLine = await GenerateWithGemini(enhancedScriptTagLine.ToString());

            StringBuilder improvements = new StringBuilder();
            improvements.Append("This previous is tv commercial script").AppendLine().AppendLine();
            improvements.Append(commercialScript.Script).AppendLine().AppendLine();
            improvements.Append("This enhanced is tv commercial script").AppendLine().AppendLine();
            improvements.Append(commercialScript.EnhancedScript).AppendLine().AppendLine();
            improvements.Append("Now, analyzing these two scripts tell me what are improvements. Give improvements with comma separated.");

            commercialScript.Improvements = await GenerateWithGemini(improvements.ToString());

            _context.CommercialScript.Add(commercialScript);
            int isSavedNew = await _context.SaveChangesAsync();

            if (isSavedNew == 1)
            {
                CommercialScriptSuggestion commercialScriptSuggestion = new()
                {
                    Id = commercialScriptSuggestionId != Guid.Empty ? commercialScriptSuggestionId : Guid.NewGuid(),
                    ProductOrServiceName = commercialScript.ProductOrServiceName,
                    CommercialScriptId = commercialScript.Id,
                    CommercialScriptInsightsId = commercialScript.CommercialScriptInsightsId,
                    OriginalScript = commercialScript.Script,
                    SuggestionsCount = commercialScript.SuggestionsCount,
                    Suggestions = commercialScript.Suggestions,
                    WeakPoints = commercialScript.WeakPoints
                };

                commercialScriptSuggestion.NumberOfWeakPoints = await GenerateWithGemini(commercialScript.WeakPoints! + " \n\n " + " How many weak points? Do not give any English words, Count weak points and give me count as just integer value. That's enough!");

                var operationSuggestions = commercialScriptSuggestionId != Guid.Empty ? _context.CommercialScriptSuggestion.Update(commercialScriptSuggestion) : _context.CommercialScriptSuggestion.Add(commercialScriptSuggestion);
                int isSavedSuggestion = await _context.SaveChangesAsync();

                CommercialScriptEnhanced commercialScriptEnhanced = new()
                {
                    Id = commercialScriptEnhancedId != Guid.Empty ? commercialScriptEnhancedId : Guid.NewGuid(),
                    ProductOrServiceName = commercialScript.ProductOrServiceName,
                    AdvertisingIdea = commercialScript.AdvertisingIdea,
                    CommercialScriptId = commercialScript.Id,
                    CommercialScriptInsightsId = commercialScript.CommercialScriptInsightsId,
                    EnhancedScript = commercialScript.EnhancedScript,
                    EnhancedScriptTagLine = commercialScript.EnhancedScriptTagLine,
                    KeyMessagesOfEnhancedScript = commercialScript.KeyMessagesOfEnhancedScript,
                    NewsCreativeContentBasedNews = commercialScript.NewsCreativeContentBasedNews,
                    OriginalScript = commercialScript.Script,
                    Improvements = commercialScript.Improvements
                };

                var operationEnhanced = commercialScriptEnhancedId != Guid.Empty ? _context.CommercialScriptEnhanced.Update(commercialScriptEnhanced) : _context.CommercialScriptEnhanced.Add(commercialScriptEnhanced);
                int isSavedEnhanced = await _context.SaveChangesAsync();

                if (isSavedSuggestion == 1 && isSavedEnhanced == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static async Task<string?> ScrapeAdaDeranaOnline(string url = "https://www.adaderana.lk/search_results.php?mode=1&show=1&query=")
        {
            StringBuilder newsCollection = new();

            try
            {
                // Create HttpClient to send a request
                HttpClient client = new HttpClient();

                // Get the HTML content from the page
                var response = await client.GetStringAsync(url);

                // Load HTML into HtmlDocument
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(response);

                // XPath to locate news story texts in the HTML structure
                var storyNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='story-text']");

                if (storyNodes != null)
                {
                    foreach (var storyNode in storyNodes.ToHashSet().Take(10))
                    {
                        newsCollection.AppendLine(storyNode.InnerText.Trim());
                    }

                    return newsCollection.ToString();

                }
                else
                {
                    Console.WriteLine("No stories found for the given query.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;

            }
        }

        static async Task<string?> GenerateWithGemini(string messageContent)
        {
            HttpClient client = new HttpClient();

            string apiKey = "AIzaSyB1y5_OyIxo51ZANyG-CBG7GO1r-7qAMKc"; // Replace with your actual API key
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = "Imagine you are creative person." },
                            new { text = messageContent }
                        }
                    }
                }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the JSON response and extract the "text" field
                using JsonDocument doc = JsonDocument.Parse(responseBody);
                JsonElement root = doc.RootElement;

                // Navigate to "candidates[0].content.parts[0].text"
                if (root.TryGetProperty("candidates", out JsonElement candidates) &&
                    candidates[0].TryGetProperty("content", out JsonElement contentElement) &&
                    contentElement.TryGetProperty("parts", out JsonElement parts) &&
                    parts[0].TryGetProperty("text", out JsonElement textElement))
                {
                    string? storyText = textElement.GetString();
                    return storyText;
                }

                return null; // Return null if the structure is not as expected
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        static string? GetCurrentTrendingQueries()
        {
            String apiKey = "351bc746505a14c05650fb9bd00add2a88bef63d5d5c8aabc281f0929c0a77b1";
            Hashtable ht = new Hashtable();
            ht.Add("engine", "google_trends_trending_now");
            ht.Add("frequency", "realtime");
            ht.Add("hl", "en");
            ht.Add("geo", "US");
            ht.Add("cat", "all");

            try
            {
                GoogleSearch search = new GoogleSearch(ht, apiKey);
                JObject data = search.GetJson();
                JToken? realtime_searches = data["realtime_searches"];

                var queryList = realtime_searches!
                            .Select(search => search["queries"]?.Select(q => q.ToString()).ToList())
                            .Where(queries => queries != null)
                            .Take(10)
                            .ToList();

                // Output the queries list
                queryList.ForEach(queries => Console.WriteLine(string.Join(", ", queries!)));
                return queryList.ToString();
            }
            catch (SerpApiSearchException ex)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(ex.ToString());

                return null;
            }

        }

        static string? GetBrandTrendingQueries(string brandName)
        {
            String apiKey = "351bc746505a14c05650fb9bd00add2a88bef63d5d5c8aabc281f0929c0a77b1";
            Hashtable ht = new Hashtable();
            ht.Add("engine", "google_trends");
            ht.Add("q", brandName);
            ht.Add("data_type", "RELATED_QUERIES");

            try
            {
                GoogleSearch search = new GoogleSearch(ht, apiKey);
                JObject data = search.GetJson();
                var related_queries = data["related_queries"];

                if (related_queries != null)
                {
                    // Access the "rising" array within "related_queries"
                    var risingQueries = related_queries["rising"] as JArray;

                    if (risingQueries != null)
                    {
                        // Extract "query" from each element in "rising"
                        var queryList = risingQueries
                                        .Select(query => query["query"]?.ToString()) // Extract the "query" field
                                        .Where(query => query != null) // Filter out nulls
                                        .Take(10) // Limit to 10 results if needed
                                        .ToList();

                        // Output the queries list
                        queryList.ForEach(query => Console.WriteLine(query));

                        return queryList.ToString();
                    }
                }

                return null;
            }
            catch (SerpApiSearchException ex)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(ex.ToString());

                return null;
            }

        }

        static async Task<string?> GetTrendingYouTubeTitles(string query)
        {
            string apiKey = "AIzaSyDGkWxwKE8R0E30BOqvtHx5aJenqCEjEG4";

            YouTubeService youTubeService = new (new BaseClientService.Initializer()
            {
                ApiKey = apiKey
            });

            var request = youTubeService.Videos.List("snippet");
            request.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
            request.RegionCode = "lk";

            var response = await request.ExecuteAsync();
            var titles = response.Items.Select(t => t.Snippet.Title.Trim().ToString()).ToList();

            var searchRequest = youTubeService.Search.List("snippet");
            searchRequest.Q = query;
            searchRequest.Type = "video";
            searchRequest.MaxResults = 5;

            var searchResponse = await searchRequest.ExecuteAsync();
            var searchVideoTitles = searchResponse.Items.Select(item => item.Snippet.Title.Trim().ToString()).ToList();

            StringBuilder titlesList = new StringBuilder();

            foreach (var title in titles.Concat(searchVideoTitles).ToList())
            {
                titlesList.Append(title).Append(",").AppendLine();
            }

            return titlesList.ToString();
        }
    }
}
