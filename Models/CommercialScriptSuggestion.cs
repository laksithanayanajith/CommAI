using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommAI.Models
{
    public class CommercialScriptSuggestion
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Product Or Service Name")]
        public string? ProductOrServiceName { get; set; }
        public string? OriginalScript { get; set; }

        [DisplayName("Number Of Weak Points")]
        public string? NumberOfWeakPoints { get; set; }

        [DisplayName("Weak Points")]
        public string? WeakPoints { get; set; }

        [DisplayName("Suggestions Count")]
        public string? SuggestionsCount { get; set; }
        public string? Suggestions { get; set; }

        [ForeignKey(nameof(Models.CommercialScriptInsights))]
        public Guid CommercialScriptInsightsId { get; set; }

        public CommercialScriptInsights? CommercialScriptInsights { get; set; }

        [ForeignKey(nameof(Models.CommercialScript))]
        public Guid? CommercialScriptId { get; set; }

        public CommercialScript? CommercialScript { get; set; }
    }
}
