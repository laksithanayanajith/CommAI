using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommAI.Models
{
    public class CommercialScript
    {
        [Key]
        public Guid Id { get; set; }
        public string? BrandName { get; set; }
        public string? ProductOrService { get; set; }
        public string? ProductOrServiceName { get; set; }
        public string? ProductOrServiceDescription { get; set; }
        public string? Promise { get; set; }
        public string? ConsumerInsights { get; set; }
        public string? Reason { get; set; }
        public string? ReasonToBelieve { get; set; }
        public string? Story { get; set; }
        public string? Script { get; set; }
        public int Duration { get; set; }
        public string? AgeGroup { get; set; }
        public string? EmotionalTone => GetEmotionalTone(AgeGroup);
        public int NumberOfKeyMessages => GetNumberOfKeyMessages(AgeGroup);
        public string? VisualAudioComplexity => GetVisualAudioComplexity(AgeGroup);
        public string? GenderGroup { get; set; }
        public string? BrandMessagingClarity => GetBrandMessagingClarity(AgeGroup);
        public string? NewsCollection { get; set; }
        public string? NewsCreativeContent { get; set; }
        public string? NewsCreativeContentBasedNews { get; set; }
        public string? CurrentTrendingQueries { get; set; }
        public string? CurrentTrendingQueriesCreativeContent { get; set; }
        public string? BrandTrendingQueries { get; set; }
        public string? BrandTrendingQueriesCreativeContent { get; set; }
        public string? TrendingYouTubeVideoTitleCollection { get; set; }
        public string? TrendingYouTubeVideoTitleCreativeContent { get; set; }
        public bool IsOriginalScriptFittedWithNewsContent { get; set; } = false;
        public bool IsOriginalScriptFittedWithCurrentTrendingQueries { get; set; } = false;
        public bool IsOriginalScriptFittedWithBrandTrendingQueries { get; set; } = false;
        public bool IsOriginalScriptFittedWithRelatedYouTubeVideoContents { get; set; } = false;
        public bool IsOriginalScriptMemorable { get; set; } = false;
        public string? WeakPoints { get; set; }
        public string? AdvertisingIdea { get; set; }
        public string? SuggestionsCount { get; set; }
        public string? Suggestions { get; set; }
        public string? EnhancedScript { get; set; }
        public string? EnhancedScriptTagLine { get; set; }
        public string? KeyMessagesOfEnhancedScript { get; set; }
        public string? Improvements { get; set; }
        public bool IsEnhancedScriptFittedWithNewsContent { get; set; } = true;
        public bool IsEnhancedScriptFittedWithCurrentTrendingQueries { get; set; } = true;
        public bool IsEnhancedScriptFittedWithBrandTrendingQueries { get; set; } = true;
        public bool IsEnhancedScriptFittedWithRelatedYouTubeVideoContents { get; set; } = true;
        public bool IsEnhancedScriptMemorable { get; set; } = true;

        [ForeignKey(nameof(Models.CommercialScriptInsights))]
        public Guid CommercialScriptInsightsId { get; set; }

        public CommercialScriptInsights? CommercialScriptInsight { get; set; }
        public CommercialScriptEnhanced? CommercialScriptEnhanced { get; set; }
        public CommercialScriptSuggestion? CommercialScriptSuggestion { get; set; }


        public string GetEmotionalTone(string? ageGroup) => ageGroup switch
        {
            "Child" => "Playful and Light",
            "Teen" => "Energetic and Bold",
            "Young Adult" => "Adventurous and Inspirational",
            "Adult" => "Confident and Trustworthy",
            "Senior" => "Calm and Nostalgic",
            _ => "Neutral"
        };

        public int GetNumberOfKeyMessages(string? ageGroup) => ageGroup switch
        {
            "Child" => 1,
            "Teen" => 2,
            "Young Adult" => 3,
            "Adult" => 3,
            "Senior" => 2,
            _ => 1
        };


        public string GetVisualAudioComplexity(string? ageGroup) => ageGroup switch
        {
            "Child" => "Simple",
            "Teen" => "Moderate",
            "Young Adult" => "Complex",
            "Adult" => "Complex",
            "Senior" => "Moderate",
            _ => "Moderate"
        };

        public string GetBrandMessagingClarity(string? ageGroup) => ageGroup switch
        {
            "Child" => "High",           
            "Teen" => "High",             
            "Young Adult" => "Medium",      
            "Adult" => "Low",            
            "Senior" => "Medium",           
            _ => "Medium"
        };

    }
}
