using API.DTOs.CourseDTO;
using API.Models;
using API.Repositories.Courses;
using API.Repositories.Users;
using API.Services.Exams;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Services.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly ICourseRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IExamService _examService;
        private readonly IMapper _mapper;

        public CoursesService(ICourseRepository repository, IUserRepository userRepository, IMapper mapper, IExamService examService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _examService = examService;
        }

        public async Task<int> AddCourseAsync(CourseForAddDTO courseForAddDTO)
        {
            var course = _mapper.Map<Course>(courseForAddDTO);
            await _repository.AddCourseAsync(course);
            return course.Id;
        }

        public async Task DeleteCourse(int course_id)
        {
            await _repository.DeleteCourse(course_id);
        }

        public async Task<bool> FindCourse(int course_id)
        {
            if (await _repository.FindCourse(course_id) != false)
                return true;
            return false;
        }

        public async Task<CourseForAddDTO> GetCourseAsync(int id)
        {

            var course = await _repository.GetCourseAsync(id);
            return _mapper.Map<CourseForAddDTO>(course);
        }

        public async Task<List<CourseForAddDTO>> GetCoursesAsync(int userId)
        {
            var courseEnlisted = await _userRepository.GetUserCourses(userId);
            var courses = await _repository.GetCoursesAsync();

            List<Course> courses_for_return = new List<Course>();
            List<Course> enlistedCourses = new List<Course>();
           
            foreach(var course in courseEnlisted.CourseEnrolment)
            {
                enlistedCourses.Add(course.Course);
            }

            courses_for_return = courses.Except(enlistedCourses).ToList();

            return _mapper.Map<List<CourseForAddDTO>>(courses_for_return);

        }

        public async Task<UserCoursesDTO> GetMyCoursesAsync(int id)
        {
            var course = await _repository.GetMyCoursesAsync(id);
            return _mapper.Map<UserCoursesDTO>(course);
        }

        //RecommendCourses
        public async Task<List<CourseForAddDTO>> RecommendCoursesAsync(int userId)
        {
            var userCourses = await _repository.GetUserComplitedCoursesAsync(userId);

            List<int> categories = new List<int>();
            List<int> distinctCategories = new List<int>();
            List<int> counter = new List<int>();

            List<CourseForAddDTO> recommendedCourses = new List<CourseForAddDTO>();

            int best = 0;
            int secondBest = 0;

            int idBest = 0;
            int idSecondBest = 0;

            if (userCourses.Count() > 0)
            {
                for (int i = 0; i < userCourses.Count(); i++)
                {
                    if (distinctCategories.Count() > 0)
                    {
                        bool flag = true;

                        for (int j = 0; j < distinctCategories.Count(); j++)
                        {
                            if (distinctCategories[j] == userCourses[i].Course.CategoryId)
                            {
                                flag = false;
                            }
                        }

                        if (flag == true)
                        {
                            distinctCategories.Add(userCourses[i].Course.CategoryId);
                        }
                    }
                    else
                    {
                        distinctCategories.Add(userCourses[i].Course.CategoryId);
                    }

                    categories.Add(userCourses[i].Course.CategoryId);
                }

                for (int q = 0; q < distinctCategories.Count(); q++)
                {
                    counter.Add(0);
                }

                for (int x = 0; x < distinctCategories.Count(); x++)
                {
                    for (int y = 0; y < categories.Count(); y++)
                    {
                        if (distinctCategories[x] == categories[y])
                        {
                            counter[x]++;
                        }
                    }
                }
                //counter.Sort();


                if (counter.Count() >= 2)
                {
                    best = counter[0];

                    for (int i = 1; i < counter.Count(); i++)
                    {
                        if (counter[i] > best)
                        {
                            secondBest = best;
                            best = counter[i];
                        }
                        else if (counter[i] > secondBest)
                        {
                            secondBest = counter[i];
                        }
                    }


                }
                else if (counter.Count() == 1)
                {
                    best = counter[0];
                }

                //jeśli użytkownik rozwiązał więcej niż jeden kurs
                if (secondBest > 0)
                {
                    idBest = distinctCategories[counter.IndexOf(best)];
                    idSecondBest = distinctCategories[counter.IndexOf(secondBest)];

                    var courses = await _repository.GetRecommendedCourses(idBest, idSecondBest);
                    recommendedCourses = _mapper.Map<List<CourseForAddDTO>>(courses);
                }
                else
                {
                    idBest = distinctCategories[counter.IndexOf(best)];

                    var courses = await _repository.GetRecommendedCourses(idBest);
                    recommendedCourses = _mapper.Map<List<CourseForAddDTO>>(courses);
                }

                for (int i = 0; i < recommendedCourses.Count(); i++)
                {
                    for (int j = 0; j < userCourses.Count(); j++)
                    {
                        if (recommendedCourses[i].Id == userCourses[j].CourseId)
                        {
                            recommendedCourses.RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }
            }
            //jeśli nie rozwiązał jeszcze żadnych kursów to poleci mu wszystkie
            else
            {
                var courses = await _repository.GetCoursesAsync();
                recommendedCourses = _mapper.Map<List<CourseForAddDTO>>(courses);
            }

            //jeśli nie ma więcej kursów z kategorii którą rozwiązuje to bierze wszystkie oprócz tych co już rozwiązał
            if (recommendedCourses.Count() == 0)
            {
                var courses = await _repository.GetCoursesAsync();
                recommendedCourses = _mapper.Map<List<CourseForAddDTO>>(courses);

                for (int i = 0; i < recommendedCourses.Count(); i++)
                {
                    for (int j = 0; j < userCourses.Count(); j++)
                    {
                        if (recommendedCourses[i].Id == userCourses[j].CourseId)
                        {
                            recommendedCourses.RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }
            }

            List<CourseForAddDTO> recommendedCoursesWithABCD = new List<CourseForAddDTO>();

            //filtorwanie
            if (recommendedCourses.Count > 0)
            {
                foreach (var course in recommendedCourses)
                {
                    var exams = await _examService.GetExamsABCDFromCourseAsync(course.Id);

                    if(exams.Count > 0)
                    {
                        recommendedCoursesWithABCD.Add(course);
                    }
                }
            }

            //gdy poleciło te kategorie które rozwiązywał ale okazało się że nie ma w nich ABCD
            if(recommendedCoursesWithABCD.Count == 0)
            {
                var courses = await _repository.GetCoursesAsync();
                recommendedCourses = _mapper.Map<List<CourseForAddDTO>>(courses);

                for (int i = 0; i < recommendedCourses.Count(); i++)
                {
                    for (int j = 0; j < userCourses.Count(); j++)
                    {
                        if (recommendedCourses[i].Id == userCourses[j].CourseId)
                        {
                            recommendedCourses.RemoveAt(i);
                            i--;
                            break;
                        }
                    }
                }

                //filtorwanie
                if (recommendedCourses.Count > 0)
                {
                    foreach (var course in recommendedCourses)
                    {
                        var exams = await _examService.GetExamsABCDFromCourseAsync(course.Id);

                        if (exams.Count > 0)
                        {
                            recommendedCoursesWithABCD.Add(course);
                        }
                    }
                }
            }

            return recommendedCoursesWithABCD;
             
           //return recommendedCourses;
        }
    }
}
