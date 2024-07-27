using AutoMapper;
using Explorer.Achievements.API.Dtos;
using Explorer.Achievements.API.Dtos.Tourist;
using Explorer.Achievements.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Achievements.Core.Mappers
{
    public class AchievementsProfile : Profile
    {
        public AchievementsProfile() 
        {
            CreateMap<AchievementDto, Achievement>().ReverseMap();
            CreateMap<InventoryDto, Inventory>().ReverseMap();
            CreateMap<AchievementModuleAchievementMobileDto, Achievement>().ReverseMap()
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon.ToString()))
                .ForMember(dest => dest.Rarity, opt => opt.MapFrom(src => src.Rarity.ToString()));
        }
    }
}
