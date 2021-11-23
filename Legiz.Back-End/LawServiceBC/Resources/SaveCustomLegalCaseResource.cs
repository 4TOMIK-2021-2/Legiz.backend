using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Legiz.Back_End.LawServiceBC.Resources
{
    public class SaveCustomLegalCaseResource
    {
        [Required]
        [NotNull]
        public string Title { get; set; }
        
        [Required]
        public string StartAt { get; set; }
        
        [Required]
        public string FinishAt { get; set; }

        [Required]
        [Range(1,2)]
        public int TypeMeet { get; set; }
        
        [Required]
        [Range(1,2)]
        public int StatusLawService { get; set; }
        
        [Required]
        public int LawyerId { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int LegalDocumentId { get; set; }
    }
}