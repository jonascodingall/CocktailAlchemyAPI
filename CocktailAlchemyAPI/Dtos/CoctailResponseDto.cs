using System.Collections.Generic;

namespace CocktailAlchemyAPI.Dtos
{
#nullable disable
    public class CoctailResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AlternateName { get; set; }
        public string Tags { get; set; }
        public string Video { get; set; }
        public string Category { get; set; }
        public string IBA { get; set; }
        public string Alcoholic { get; set; }
        public string Glass { get; set; }
        public string Instructions { get; set; }
        public Dictionary<string, string> InstructionsInLanguages { get; set; } // Use a dictionary for instructions in multiple languages
        public string ImageUrl { get; set; }
        public List<string> Ingredients { get; set; } // Use a list for ingredients
        public List<string> Measures { get; set; } // Use a list for measures
        public string ImageSource { get; set; }
        public string ImageAttribution { get; set; }
        public string CreativeCommonsConfirmed { get; set; }
        public string DateModified { get; set; }
    }
}
