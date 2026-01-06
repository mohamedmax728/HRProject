using Modules.TaskManagement.Application.Features.Project.Dtos;
using Modules.TaskManagement.Application.Features.Task.Dtos;
using Modules.TaskManagement.Application.Features.User.Dtos;
using Modules.TaskManagement.Domain.Entities;

namespace Modules.TaskManagement.Application.Profiles
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            #region Project Mappings
            CreateMap<CreateProjectRequest, Project>()
                .ReverseMap();
            CreateMap<UpdateProjectRequest, Project>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProjectId))
                .ReverseMap();
            CreateMap<Project, ProjectListResponse>()
                .ForMember(dest => dest.ManagerFullName, opt => opt.MapFrom(src => src.Manager.FullName))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            #endregion
            #region Task Mappings
            CreateMap<CreateUserRequest, User>()
                .ReverseMap();
            CreateMap<UpdateUserRequest, User>()
                .ReverseMap();
            #endregion
            #region Task Mappings
            CreateMap<CreateTaskRequest, Domain.Entities.Task>()
                .ReverseMap();
            CreateMap<UpdateTaskRequest, Domain.Entities.Task>()
                .ReverseMap();
            #endregion

        }
    }
}
