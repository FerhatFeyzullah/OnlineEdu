﻿using System.Runtime.CompilerServices;
using OnlineEdu.Business.Configurations;
using OnlineEdu.Business.Interface;
using OnlineEdu.Business.Management;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.DataAccess.Repositories;

namespace OnlineEdu.API.Extensions
{
    public static class ServiceExtesions
    {
        public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryManager>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseManager>();

            services.AddScoped<ICourseRegisterRepository, CourseRegisterRepository>();
            services.AddScoped<ICourseRegisterService, CourseRegisterManager>();

            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddScoped<IBlogCategoryService, BlogCategoryManager>();

            services.AddScoped<ICourseVideoRepository, CourseVideoRepository>();
            services.AddScoped<ICourseVideoService, CourseVideoManager>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IJwtService, JwtManager>();

            services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));


        }
    }
}
