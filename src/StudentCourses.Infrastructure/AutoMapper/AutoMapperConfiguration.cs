using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentCourses.Domain.Models;
using StudentCourses.Infrastructure.EntityModel;

namespace StudentCourses.Infrastructure.AutoMapper
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentEntityModel>().MaxDepth(2);
            CreateMap<Course, CourseEntityModel>().MaxDepth(2);
            CreateMap<Registration, RegistrationEntityModel>().MaxDepth(2);

            CreateMap<StudentEntityModel, Student>().MaxDepth(2);
            CreateMap<CourseEntityModel, Course>().MaxDepth(2);
            CreateMap<RegistrationEntityModel, Registration>().MaxDepth(2);
        }
    }
}
