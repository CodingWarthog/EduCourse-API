using API.DTOs.CourseEnrolmentDTO;
using API.Models;
using API.Repositories.CourseEnrolments;
using AutoMapper;
using System;
using System.Threading.Tasks;


namespace API.Services.CourseEnrolments
{
    public class CourseEnrolmentsService : ICourseEnrolmentsService
    {
        private readonly ICourseEnrolmentsRepository _repository;
        private readonly IMapper _mapper;

        public CourseEnrolmentsService(ICourseEnrolmentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteEnrolment(int user_id, int course_id)
        {
            await _repository.DeleteEnrolment(user_id, course_id);
            return true;
        }

        public async Task<DateTime> EnrolCourseAsync(EnrolDTO enrolDTO)
        {
            var enrolment = _mapper.Map<CourseEnrolment>(enrolDTO);
            await _repository.EnrolCourseAsync(enrolment);
            return enrolDTO.EnrolmentDate;
        }
        public async Task<bool> FindCourse(int course_id)
        {
            if (await _repository.FindCourse(course_id) != false)
                return true;
            return false;
        }

        public async Task<bool> FindCourseEnrolment(int user_id, int course_id)
        {
            if (await _repository.FindCourseEnrolment(user_id, course_id) != false)
                return true;
            return false;
        }

        public async Task<bool> FindUser(int user_id)
        {
            if (await _repository.FindUser(user_id) != false)
                return true;
            return false;
        }

        public async Task<bool> SaveAll()
        {
           return await _repository.SaveAll();
        }
    }
}
