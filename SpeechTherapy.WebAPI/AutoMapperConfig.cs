using AutoMapper;
using SpeechTherapy.Model.Entities;
using SpeechTherapy.Service.EnumHelpers;
using SpeechTherapy.WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeechTherapy.WebAPI
{
    public class AutoMapperConfig
    {
        public static void Initialize()									
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Client, ClientGetAllDto>()
                 .ForMember(d => d.StatusName,
                op => op.ResolveUsing(o => MapClientStatus(o.StatusName)));

                config.CreateMap<Therapy, TherapyDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.DayOfTheWeek, opt => opt.MapFrom(src => src.Date.DayOfWeek))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TherapistId, opt => opt.MapFrom(src => src.TherapistId))
                ;

                config.CreateMap<Client, ClientNameDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;
                //tu powinno być Therapist, TherapistGetAllDto ale nie piszę bo zadziałało bez tego
            });
        }
        public static string MapClientStatus(string statusName)
        {
            if (statusName == null)
            {
                return null;
            }
            //TODO: function to map a string to a SchoolGradeDTO
            return ClientStatusEnumHelper.GetEnumStringValue(statusName);
        }
    }
}