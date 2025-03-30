using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace _71MY_TraversalCore.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddAnnouncementDTO, Announcement>();
            CreateMap<Announcement, AddAnnouncementDTO>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();

            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();

            CreateMap<UpdateAnnouncementDTO, Announcement>();
            CreateMap<Announcement, UpdateAnnouncementDTO>();

            CreateMap<SendMessageDTO, ContactUsMessage>().ReverseMap();
        }
    }
}
