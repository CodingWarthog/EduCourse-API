using API.DTOs.AssetDTO;
using API.DTOs.BadgeDTO;
using API.DTOs.BlockItemDTO;
using API.DTOs.CategoryDTO;
using API.DTOs.CourseDTO;
using API.DTOs.CourseEnrolmentDTO;
using API.DTOs.ExamDTO;
using API.DTOs.ExamResultDTO;
using API.DTOs.ExperienceDTO;
using API.DTOs.FlashcardDTO;
using API.DTOs.FlashcardSetDTO;
using API.DTOs.MovingBlockDTO;
using API.DTOs.QuestionDTO;
using API.DTOs.UserDTO;
using API.DTOs.UserDTO.Auth;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<UserForRegisterDTO, User>();
            CreateMap<CategoryDTO, Category>();
            // CreateMap<PhotoForCreationDto, Asset>();


            // exam
            CreateMap<ExamDTO, Course>().ReverseMap();
            CreateMap<ExamsDTO, Exam>().ReverseMap();
            CreateMap<UserForExamsDTO, User>().ReverseMap()
                .ForMember(dest => dest.MyCourseExams, opt =>
                {
                    opt.MapFrom(src => src.Course);
                });

            //CreateMap<CourseForExamsDTO, Course>().ReverseMap();

            CreateMap<CourseForExamsDTO, Course>().ReverseMap()
                 .ForMember(dest => dest.MyExams, opt =>
                 {
                     opt.MapFrom(src => src.Exam);
                 });
            CreateMap<QuestionsForExamsDTO, Question>().ReverseMap();
            // asset
            CreateMap<AssetListDTO, Asset>().ReverseMap();
            CreateMap<UserAssetListDTO, User>().ReverseMap();

            CreateMap<KursGetDTO, Course>().ReverseMap();
            CreateMap<ExamGetDTO, Exam>().ReverseMap();

            // enrolment
            CreateMap<EnrolDTO, CourseEnrolment>().ReverseMap();

            // examresult
            CreateMap<UserExamResultListDTO, User>().ReverseMap();
            CreateMap<ExamResultListDTO, ExamResult>().ReverseMap();
            //CreateMap<QuestionResultDTO, QuestionResult>().ReverseMap();

            // flashcard
            CreateMap<FlashcardSetForCardsDTO, FlashcardSet>().ReverseMap();
            CreateMap<FlashcardListDTO, Flashcard>().ReverseMap();

            // flashcardset
            CreateMap<FlashcardSetsDTO, FlashcardSet>().ReverseMap();
            CreateMap<UserFlashcardSetsDTO, User>().ReverseMap();

            // questions
            CreateMap<QuestionDTO, Question>().ReverseMap();

            // course
            CreateMap<CourseForAddDTO, Course>().ReverseMap();
            CreateMap<UserCoursesDTO, User>().ReverseMap();
            CreateMap<UserInfoUpdateDTO, User>().ReverseMap();

            // user
            CreateMap<UserInfoDTO, User>().ReverseMap();
            CreateMap<RoleDTO, IdentityRole>().ReverseMap();
            //CreateMap<UserRolesDTO, UserRole>().ReverseMap();

            CreateMap<UserForCourseDTO, User>().ReverseMap();
            CreateMap<CourseForEnrolmentDTO, Course>().ReverseMap();
            CreateMap<EnrolCourseDTO, CourseEnrolment>().ReverseMap();


            CreateMap<UserAllExamsGetDTOs, User>().ReverseMap();

            CreateMap<AddCourseDTOs, Exam>().ReverseMap();
            CreateMap<CourseEnrolmentGetDTOs, User>().ReverseMap();
            CreateMap<CourseForEnrolDTOs, Course>().ReverseMap();
            CreateMap<EnrolmentsDTOs, CourseEnrolment>()
                .ForMember(dest => dest.Course, opt =>
                {
                    opt.MapFrom(src => new Course
                    {
                        Id = src.Id,
                        Name = src.Name,
                        Description = src.Description,
                        Other = src.Other
                    });
                }).ReverseMap();

            CreateMap<BlockItemDTO, BlockItem>().ReverseMap();
         
            CreateMap<BlockItemForAddDTO, BlockItem>().ReverseMap();
            CreateMap<BlockItemForListDTO, BlockItem>().ReverseMap();

            CreateMap<BadgeForAddDTO, Badges>().ReverseMap();
            CreateMap<UserForBadgeDTO, User>().ReverseMap();
            CreateMap<BadgeAssignmentDTO, BadgeAssignment>().ReverseMap();
            CreateMap<BlocksForExamDTO, BlockItem>().ReverseMap();
            CreateMap<ExamBlockDTO, Exam>().ReverseMap();

            CreateMap<ExperienceForListDTO, Experience>().ReverseMap();
            CreateMap<UserExperienceDTO, User>().ReverseMap();
            CreateMap<RoleUpdateDTO, User>().ReverseMap();
            // Exam Controller


            // .ForMember(dest => dest.Name, opt =>
            // {
            //     opt.MapFrom(src => src.Course.Name);
            // })
            //  .ForMember(dest => dest.Description, opt =>
            //  {
            //      opt.MapFrom(src => src.Course.Description);
            //  })
            //   .ForMember(dest => dest.Other, opt =>
            //   {
            //       opt.MapFrom(src => src.Course.Other);
            //   });
            //CreateMap<User, UserForDetailedDto>()
            //   .ForMember(dest => dest.PhotoUrl, opt => {
            //       opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            //   })
            //   .ForMember(dest => dest.Age, opt => {
            //       opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
            //   });

        }
    }
}