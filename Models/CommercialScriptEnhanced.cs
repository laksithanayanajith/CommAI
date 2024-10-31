using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommAI.Models
{
    public class CommercialScriptEnhanced
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Product Or Service Name")]
        public string? ProductOrServiceName { get; set; }

        [DisplayName("Original Script")]
        public string? OriginalScript { get; set; }

        [DisplayName("Advertising Idea")]
        public string? AdvertisingIdea { get; set; }

        [DisplayName("Enhanced Script")]
        public string? EnhancedScript { get; set; }

        [DisplayName("Enhanced Script Tagline")]
        public string? EnhancedScriptTagLine { get; set; }

        [DisplayName("Improvements")]
        public string? Improvements { get; set; }

        [DisplayName("Key Messages Of Enhanced Script")]
        public string? KeyMessagesOfEnhancedScript { get; set; }

        [DisplayName("Based News")]
        public string? NewsCreativeContentBasedNews { get; set; }

        [ForeignKey(nameof(Models.CommercialScriptInsights))]
        public Guid CommercialScriptInsightsId { get; set; }

        public CommercialScriptInsights? CommercialScriptInsights { get; set; }

        [ForeignKey(nameof(Models.CommercialScript))]
        public Guid? CommercialScriptId { get; set; }

        public CommercialScript? CommercialScript { get; set; }
    }
}
