using API.DTOs.CourseDTO;
using API.DTOs.ExamDTO;
using API.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ExamDTO>> GetExamsFromCourseAsync(int id)
        {
            var exams = await _repository.GetExamsFromCourseAsync(id);

            return _mapper.Map<List<ExamDTO>>(exams.Exam);
        }

        public async Task<List<ExamDTO>> GetExamsABCDFromCourseAsync(int id)
        {
            var course = await _repository.GetExamsFromCourseAsync(id);

            List<Exam> examsList = new List<Exam>();

            foreach (var exam in course.Exam)
            {
                if (exam.Type == "Zwykly")
                {
                    examsList.Add(exam);
                }

            }
            return _mapper.Map<List<ExamDTO>>(examsList);
        }

        public async Task<CourseForExamsDTO> GetExamsFromCourseAngularAsync(int id)
        {
            var exams = await _repository.GetExamsFromCourseAsync(id);

            return _mapper.Map<CourseForExamsDTO>(exams);
        }

        public async Task <List<ExamGetDTO>> GetExamsCreatedByUserAsync(int id)
        {
            var exams = await _repository.GetExamsCreatedByUserAsync(id);
            List<Exam> exam_normal = new List<Exam>();
            foreach(var exam in exams.Course)
            {
                foreach (var ex in exam.Exam)
                {
                    if(ex.Type == "Zwykly")
                    {
                        exam_normal.Add(ex);
                    }
                   
                }
            }
            
            return _mapper.Map<List<ExamGetDTO>>(exam_normal);
        }

        public async Task<ExamsDTO> GetQuestionsForExamAsync(int id)
        {
            var questions = await _repository.GetQuestionsForExamAsync(id);
            return _mapper.Map<ExamsDTO>(questions);
        }

        public async Task<List<QuestionsForExamsDTO>> GetQuestionsForExamMobAsync(int id)
        {
            var questions = await _repository.GetQuestionsForExamAsync(id);
            return _mapper.Map<List<QuestionsForExamsDTO>>(questions.Question);
        }

        public async Task<UserForExamsDTO> GetExamsOfEnrolmentCoursesAsync(int id)
        {
            var exams = await _repository.GetExamsOfEnrolmentCoursesAsync(id);
            return _mapper.Map<UserForExamsDTO>(exams);
        }

        public async Task<int> AddExamAsync(ExamsDTO examsDTO)
        {
            var examToCreate = _mapper.Map<Exam>(examsDTO);
            await _repository.AddExamAsync(examToCreate);
            return examToCreate.Id;
        }
        public async Task DeleteExam(int exam_id)
        {
            await _repository.DeleteExam(exam_id);
        }

        public async Task<bool> FindExam(int exam_id)
        {
            if (await _repository.FindExam(exam_id) != false)
                return true;
            return false;
        }

        public async Task<ExamBlockDTO> GetBlockItemForExamAsync(int id)
        {
            var questions = await _repository.GetBlocksForExamAsync(id);
            return _mapper.Map<ExamBlockDTO>(questions);
        }

        public async Task<CourseForAddDTO> GetCategoryOfExamAsync(int courseId)
        {
            var category = await _repository.GetCategoryOfExamAsync(courseId);
            return _mapper.Map<CourseForAddDTO>(category);
        }

        public async Task<List<ExamGetDTO>> GetDraftExamsCreatedByUserAsync(int id)
        {
            var exams = await _repository.GetExamsCreatedByUserAsync(id);
            List<Exam> exam_draft = new List<Exam>();
            foreach (var exam in exams.Course)
            {
                foreach (var ex in exam.Exam)
                {
                    if (ex.Type == "Ustalanie kolejnosci")
                    {
                        exam_draft.Add(ex);
                    }

                }
            }

            return _mapper.Map<List<ExamGetDTO>>(exam_draft);
        }

        public async Task<List<ExamGetDTO>> GetNormalExamsCreatedByUserAsync(int id)
        {
            var exams = await _repository.GetExamsCreatedByUserAsync(id);
            List<Exam> exam_draft = new List<Exam>();
            foreach (var exam in exams.Course)
            {
                foreach (var ex in exam.Exam)
                {
                    if (ex.Type == "Zwykly")
                    {
                        exam_draft.Add(ex);
                    }

                }
            }

            return _mapper.Map<List<ExamGetDTO>>(exam_draft);
        }
    }
}
