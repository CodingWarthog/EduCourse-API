using API.DTOs.CourseDTO;
using API.DTOs.UserDTO;
using API.Models;
using API.Repositories.Users;
using API.Services.Exams;
using API.Services.Users;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;

        public UserService(IUserRepository repository, IMapper mapper, IExamRepository examRepository)
        {
            _repository = repository;
           _mapper = mapper;
            _examRepository = examRepository;
        }
        public async Task<UserInfoDTO> GetUserInfoAsync(int id)
        {
            var info = await _repository.GetUserInfoAsync(id);
            return _mapper.Map<UserInfoDTO>(info);
        }
        public async Task<List<CourseForAddDTO>> GetUserCourses(int id)
        {
            var courses = await _repository.GetUserCourses(id);
            List<Course> courses_for_return = new List<Course>();

            foreach (var course in courses.CourseEnrolment)
            {
                courses_for_return.Add(course.Course);
            }
            

            return _mapper.Map<List<CourseForAddDTO>>(courses_for_return);
        }
        public async Task<int> UpdateUserInfoAsync(int id, UserInfoUpdateDTO userInfoDTO)
        {
            var userFromBase = _repository.GetUserFromBase(id);


            if (userInfoDTO.Firstname!="" && userInfoDTO.Firstname != null)
            {
                userInfoDTO.Firstname = userInfoDTO.Firstname;
            } else
            {
                userInfoDTO.Firstname = userFromBase.Firstname;
            }

            if (userInfoDTO.Lastname != "" && userInfoDTO.Firstname != null)
            {
                userInfoDTO.Lastname = userInfoDTO.Lastname;
            }
            else
            {
                userInfoDTO.Lastname = userFromBase.Lastname;
            }

            if (userInfoDTO.Username != "" && userInfoDTO.Firstname != null)
            {
                userInfoDTO.Username = userInfoDTO.Username;
            }
            else
            {
                userInfoDTO.Username = userFromBase.Username;
            }

            if (userInfoDTO.Email != "" && userInfoDTO.Firstname != null)
            {
                userInfoDTO.Email = userInfoDTO.Email;
            }
            else
            {
                userInfoDTO.Email = userFromBase.Email;
            }
            var userInfo = _mapper.Map(userInfoDTO, userFromBase);
            await _repository.UpdateUserInfoAsync(userInfo);
            return userInfo.Id;

        }
        public async Task<bool> UserExistsAsync(string username)
        {
            if (await _repository.UserExistsAsync(username))
                return true;

            return false;
        }
        public bool UserExists(int id)
        {
            return _repository.UserExists(id);
        }

        public async Task<List<UserInfoDTO>> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();
            return _mapper.Map<List<UserInfoDTO>>(users);
        }

        public async Task<int> UpdateRoleAsync(int id, RoleUpdateDTO roleUpdateDTO)
        {
            var userFromBase = _repository.GetUserFromBase(id);

            var userInfo = _mapper.Map(roleUpdateDTO, userFromBase);

            await _repository.UpdateRoleAsync(userInfo);
            return userInfo.Id;
        }

        public async Task<UserInfoDTO> GetUserByUsername(string username)
        {
            var info = await _repository.GetUserByUsername(username);
            return _mapper.Map<UserInfoDTO>(info);
        }

        public async Task<List<CourseList>> GetQuantityOfCoursesByCategory()
        {
            //var listOfCategories = await _repository.GetCategories();
            //List<CourseList> Courses = new List<CourseList>();

            //foreach (var category in listOfCategories)
            //{
            //    var coursesTemporary = await _repository.GetNumberOfCoursesByCategory(category.Id);
            //    foreach (var course in coursesTemporary)
            //    {
            //        Courses.Add(course);
            //    }

            //}
            throw new System.NotImplementedException();
            //return numberOfCourses;
        }

        public async Task<Mark> GetMarksStatistics(int userId)
        {
            Mark mark = new Mark();

            var numberOfNegativeMark = await _repository.GetNumberNegativeMark(userId);
            var numberOfPositiveMark = await _repository.GetNumberPositiveMark(userId);

            mark.numberOfNegativeMarks = numberOfNegativeMark;
            mark.numberOfPositiveMarks = numberOfPositiveMark;

            return mark;
        }

        public Task<UserInfoDTO> GetQuantityOfExamsByCategory(string username)
        {
            throw new System.NotImplementedException();
        }


        public async Task<StatiticsOverall> GetOverallStatistics()
        {
            StatiticsOverall statitics = new StatiticsOverall();

            var numberOfCourses = await _repository.GetNumberOfAvailableCourses();
            var numberOfExams = await _repository.GetNumberOfAvaialableExams();
            var numberOfSets = await _repository.GetNumberOfFlashcardSets();
            var numberOfMaterials = await _repository.GetNumberOfAvailableMaterials();
            var numberOfUsers = await _repository.GetNumberOfRegisteredUsers();
            var numberOfCategory = await _repository.GetNumberOfCategory();
            var numberOfBadges = await _repository.GetNumberOfBadges();

            statitics.numberOfCourse = numberOfCourses;
            statitics.numberOfExams = numberOfExams;
            statitics.numberOfSets = numberOfSets;
            statitics.numberOfEMaterials = numberOfMaterials;
            statitics.numberOfERegisteredUsers = numberOfUsers;
            statitics.numberOfCategory = numberOfCategory;
            statitics.numberOfBadges = numberOfBadges;

            return statitics;

        }

        public async Task<PersonalStatistics> GetPersonalStatistics(int userId)
        {
            PersonalStatistics statistics = new PersonalStatistics();

            // enrolment courses
            var enrolmentCourses = await _repository.GetUserCourses(userId);
            int numberOfEnrolmentCourses = 0;
            foreach (var enrolment in enrolmentCourses.CourseEnrolment)
            {
                numberOfEnrolmentCourses++;
            }
            // enrolment exams
            var enrolmentExams = await _examRepository.GetExamsOfEnrolmentCoursesAsync(userId);
            int numberOfEnrolmentExams = 0;
            foreach (var enrolment in enrolmentExams.CourseEnrolment)
            {
                foreach (var course in enrolment.Course.Exam)
                {
                    numberOfEnrolmentExams++;
                }
            }
            // added courses
            var numberOfAddedCourses = await _repository.GetNumberOfAddedCourses(userId);

            // added materials
            var numberOfAddedMaterials = await _repository.GetNumberOfAddedMaterials(userId);

            // added materials
            var assignedBadges = await _repository.GetNumberOfAssignedBadges(userId);
            int numberOfAssignedBadge = 0;
            foreach (var enrolment in assignedBadges.BadgeAssignment)
            {
                numberOfAssignedBadge++;
            }

            statistics.numberOfEnrolmentCourses = numberOfEnrolmentCourses;
            statistics.numberOfEnrolmentExams = numberOfEnrolmentExams;
            statistics.numberOfAddedCourses = numberOfAddedCourses;
            statistics.numberOfAddedMaterials = numberOfAddedMaterials;
            statistics.numberOfAssignedBadges = numberOfAssignedBadge;

            return statistics;
        }


    }
}
