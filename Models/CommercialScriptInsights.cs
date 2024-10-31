using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommAI.Models
{
    public class CommercialScriptInsights
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter the brand name.")]
        [DisplayName("Brand Name")]
        public string? BrandName { get; set; }

        [Required(ErrorMessage = "Please specify the product or service.")]
        [DisplayName("Product or Service")]
        public string? ProductOrService { get; set; }

        [Required(ErrorMessage = "Please enter the name of the product or service.")]
        [DisplayName("Product or Service Name")]
        public string? ProductOrServiceName { get; set; }

        [Required(ErrorMessage = "Please provide a description for the product or service.")]
        [DisplayName("Product or Service Description")]
        public string? ProductOrServiceDescription { get; set; }

        [Required(ErrorMessage = "Please provide the promise for your product or service.")]
        public string? Promise { get; set; }

        [Required(ErrorMessage = "Please provide consumer insights and needs.")]
        [DisplayName("Consumer Insights and Needs")]
        public string? ConsumerInsights { get; set; }

        [Required(ErrorMessage = "Please explain the reason for your product or service.")]
        public string? Reason { get; set; }

        [Required(ErrorMessage = "Please provide the reason to believe.")]
        [DisplayName("Reason to Believe")]
        public string? ReasonToBelieve { get; set; }

        [Required(ErrorMessage = "Please include a story for your commercial.")]
        public string? Story { get; set; }

        [Required(ErrorMessage = "Please provide a script for the commercial.")]
        public string? Script { get; set; }

        [Required(ErrorMessage = "Please specify the duration of the commercial in seconds.")]
        [DisplayName("Duration (in Seconds)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please specify the target age group.")]
        [DisplayName("Age Group")]
        public string? AgeGroup { get; set; }

        [Required(ErrorMessage = "Please specify the target gender group.")]
        public string? GenderGroup { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string? IdentityUserId { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        public CommercialScript? CommercialScript { get; set; }
        public CommercialScriptEnhanced? CommercialScriptEnhanced { get; set; }
        public CommercialScriptSuggestion? CommercialScriptSuggestion { get; set; }
    }
}
