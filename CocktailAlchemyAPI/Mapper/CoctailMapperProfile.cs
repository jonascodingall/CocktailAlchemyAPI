using AutoMapper;
using CocktailAlchemyAPI.Dtos;
using System.Collections.Generic;

namespace CocktailAlchemyAPI.Mapper
{
    public class CoctailMapperProfile : Profile
    {
        public CoctailMapperProfile()
        {
            CreateMap<CoctailInputResponseDto, CoctailResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AlternateName, opt => opt.MapFrom(src => src.AlternateName))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Video, opt => opt.MapFrom(src => src.Video))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.IBA, opt => opt.MapFrom(src => src.IBA))
                .ForMember(dest => dest.Alcoholic, opt => opt.MapFrom(src => src.Alcoholic))
                .ForMember(dest => dest.Glass, opt => opt.MapFrom(src => src.Glass))
                .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src => src.Instructions))
                .ForMember(dest => dest.InstructionsInLanguages, opt => opt.MapFrom(src => new Dictionary<string, string>
                {
                    {"Spanish", src.InstructionsSpanish},
                    {"German", src.InstructionsGerman},
                    {"French", src.InstructionsFrench},
                    {"Italian", src.InstructionsItalian},
                    {"ChineseSimplified", src.InstructionsChineseSimplified},
                    {"ChineseTraditional", src.InstructionsChineseTraditional}
                }))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => GetIngredientsList(src)))
                .ForMember(dest => dest.Measures, opt => opt.MapFrom(src => GetMeasuresList(src)))
                .ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => src.ImageSource))
                .ForMember(dest => dest.ImageAttribution, opt => opt.MapFrom(src => src.ImageAttribution))
                .ForMember(dest => dest.CreativeCommonsConfirmed, opt => opt.MapFrom(src => src.CreativeCommonsConfirmed))
                .ForMember(dest => dest.DateModified, opt => opt.MapFrom(src => src.DateModified));
            
        }

        private List<string> GetIngredientsList(CoctailInputResponseDto src)
        {
            var ingredients = new List<string>();
            for (int i = 1; i <= 15; i++)
            {
                var ingredientProperty = src.GetType().GetProperty($"Ingredient{i}");
                if (ingredientProperty != null)
                {
                    var ingredientValue = (string)ingredientProperty.GetValue(src)!;
                    if (!string.IsNullOrWhiteSpace(ingredientValue))
                        ingredients.Add(ingredientValue);
                }
                else
                {
                    // No more ingredients, break the loop
                    break;
                }
            }
            return ingredients;
        }

        private List<string> GetMeasuresList(CoctailInputResponseDto src)
        {
            var measures = new List<string>();
            for (int i = 1; i <= 15; i++)
            {
                var measureProperty = src.GetType().GetProperty($"Measure{i}");
                if (measureProperty != null)
                {
                    var measureValue = (string)measureProperty.GetValue(src)!;
                    if (!string.IsNullOrWhiteSpace(measureValue))
                        measures.Add(measureValue);
                }
                else
                {
                    // No more measures, break the loop
                    break;
                }
            }
            return measures;
        }
    }
}
