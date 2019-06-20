using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using API.Helpers;
using API.Models;
using API.Repositories.Assets;
using API.Repositories.Auth;
using API.Repositories.Badge;
using API.Repositories.BlockItems;
using API.Repositories.Categories;
using API.Repositories.CourseEnrolments;
using API.Repositories.Courses;
using API.Repositories.ExamResults;
using API.Repositories.Experiences;
using API.Repositories.Flashcards;
using API.Repositories.Questions;
using API.Repositories.Users;
using API.Services.Assets;
using API.Services.Auth;
using API.Services.Badge;
using API.Services.BlockItems;
using API.Services.Categories;
using API.Services.CourseEnrolments;
using API.Services.Courses;
using API.Services.ExamResults;
using API.Services.Exams;
using API.Services.Experiences;
using API.Services.Flashcards;
using API.Services.FlashcardSets;
using API.Services.Questions;
using API.Services.Users;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddDirectoryBrowser();

            //Mapper.Initialize(cfg => cfg.AddProfile<AutoMappersProfiles>());
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<educoursedbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICoursesService, CoursesService>();

            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamService, ExamService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ICourseEnrolmentsRepository, CourseEnrolmentsRepository>();
            services.AddScoped<ICourseEnrolmentsService, CourseEnrolmentsService>();

            services.AddScoped<IFlashcardSetsRepository, FlashcardSetsRepository>();
            services.AddScoped<IFlashcardSetsService, FlashcardSetsService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IFlashcardsRepository, FlashcardsRepository>();
            services.AddScoped<IFlashcardsService, FlashcardsService>();

            services.AddScoped<IExamResultsRepository, ExamResultsRepository>();
            services.AddScoped<IExamResultsService, ExamResultsService>();

            services.AddScoped<IAssetsRepository, AssetsRepository>();
            services.AddScoped<IAssetsService, AssetsService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IBlockItemRepository, BlockItemRepository>();
            services.AddScoped<IBlockItemService, BlockItemService>();

            services.AddScoped<IBadgeRepository, BadgeRepository>();
            services.AddScoped<IBadgeService, BadgeService>();

            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IExperienceService, ExperienceService>();

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }
             else
             {
                 app.UseHsts();
             }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            /*app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "image/png"
            });*/

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseMvc();

        }
    }
}
