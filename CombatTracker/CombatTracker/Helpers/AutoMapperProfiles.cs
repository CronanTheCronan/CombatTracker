using AutoMapper;
using CombatTracker.Dtos;
using CombatTracker.Models;
using System;

namespace CombatTracker.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UserForListDto>();
            CreateMap<UserForRegisterDto, Users>();

            CreateMap<HeroToCreateDto, Heroes>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.CreatedByUserId, opt => opt.MapFrom(s => s.CreatedBy))
                .AfterMap((s, d) => d.CreatedDate = DateTime.Now)
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now)
                .ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<HeroToCreateDto, HeroesExtended>()
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
                .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.CreatedBy))
                .AfterMap((s, d) => d.CreatedDate = DateTime.Now)
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now)
                .ReverseMap().ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<HeroToUpdateDto, Heroes>()
                .ForMember(d => d.CreatedByUserId, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now)
                .ReverseMap().ForMember(s => s.UserId, opt => opt.Ignore());
            CreateMap<HeroExtToUpdateDto, HeroesExtended>()
                .ForMember(d => d.CreatedBy, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.LastModifiedBy))
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now);
            CreateMap<MonsterToCreateDto, Monsters>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.CreatedByUser, opt => opt.MapFrom(s => s.CreatedBy))
                .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.CreatedBy))
                .AfterMap((s, d) => d.CreatedDate = DateTime.Now)
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now)
                .ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<MonsterToCreateDto, MonstersExtended>()
                .ForMember(d => d.CreatedByUser, opt => opt.MapFrom(s => s.CreatedBy))
                .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.CreatedBy))
                .AfterMap((s, d) => d.CreatedDate = DateTime.Now)
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now)
                .ReverseMap().ForAllOtherMembers(opt => opt.Ignore());
            CreateMap<MonsterToUpdateDto, Monsters>()
                .ForMember(d => d.CreatedByUser, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now)
                .ReverseMap().ForMember(s => s.UserId, opt => opt.Ignore());
            CreateMap<MonsterExtToUpdateDto, MonstersExtended>()
                .ForMember(d => d.CreatedByUser, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.LastModifiedBy))
                .AfterMap((s, d) => d.LastModifiedDate = DateTime.Now);
        }
    }
}
