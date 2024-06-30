using AutoMapper;
using Katmanli.Core.Interfaces.DataAccessInterfaces;
using Katmanli.Core.Interfaces.IUnitOfWork;
using Katmanli.Core.Response;
using Katmanli.Core.SharedLibrary;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using Katmanli.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Services
{
    public class ProjectService : IProjectService
    {

        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IGenericRepository<Project> projectRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IResponse<string> Create(ProjectCreate model)
        {
            var newProject = Project.FactoryMethod(model);

            if (newProject == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Proje"));
            }

            _projectRepository.AddAsync(newProject);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Proje"));
        }

        public IResponse<string> Delete(int id)
        {
            var deleteThisProject = _projectRepository.GetByIdAsync(id).Result;

            if (deleteThisProject == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Proje"));
            }

            _projectRepository.Delete(deleteThisProject);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Delete("Proje"));
        }

        public IResponse<IEnumerable<ProjectQuery>> ListAll()
        {
            var projects = _projectRepository.GetAll().ToList();

            if (projects == null || !projects.Any())
            {
                return new ErrorResponse<IEnumerable<ProjectQuery>>(Messages.NotFound("Proje"));
            }

            var projectQueries = _mapper.Map<IEnumerable<ProjectQuery>>(projects);

            return new SuccessResponse<IEnumerable<ProjectQuery>>(projectQueries);
        }

        public IResponse<string> Update(ProjectUpdate model)
        {
            var updateThisProject = _projectRepository.GetByIdAsync(model.Id).Result;

            if (updateThisProject == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Proje"));
            }

            updateThisProject.ProjectName = model?.ProjectName;
            updateThisProject.Description = model?.Description;
            updateThisProject.UpdatedDate = DateTime.Now;

            _projectRepository.Update(updateThisProject);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Update("Proje"));
        }
    }
}

