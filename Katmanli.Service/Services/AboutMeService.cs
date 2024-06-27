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
    public class AboutMeService : IAboutMeService
    {

        private readonly IGenericRepository<AboutMe> _aboutMeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AboutMeService(IGenericRepository<AboutMe> aboutMeRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _aboutMeRepository = aboutMeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(AboutMeCreate model)
        {
            var newAboutMe = AboutMe.FactoryMethod(model);

            if (newAboutMe == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Hakkımda"));
            }


            _aboutMeRepository.AddAsync(newAboutMe);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Hakkımda"));
        }

        public IResponse<string> Delete(int id)
        {
           
            var deleteThisAboutMe = _aboutMeRepository.GetByIdAsync(id).Result;

            if (deleteThisAboutMe == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Hakkımda"));
            }

            _aboutMeRepository.Delete(deleteThisAboutMe);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Delete("Hakkımda"));
        }

        public IResponse<IEnumerable<AboutMeQuery>> List()
        {
            var getAboutMe = _aboutMeRepository.GetAll().ToList();

            if (getAboutMe == null)
            {
                return new ErrorResponse<IEnumerable<AboutMeQuery>>(Messages.NotFound("Hakkımda"));
            }

            var aboutMeQuery = _mapper.Map<IEnumerable<AboutMeQuery>>(getAboutMe);

            return new SuccessResponse<IEnumerable<AboutMeQuery>>(aboutMeQuery);
        }

        public IResponse<string> Update(AboutMeUpdate model)
        {
            var updateThisAboutMe = _aboutMeRepository.GetByIdAsync(model.Id).Result;

            if (updateThisAboutMe == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Hakkımda"));
            }

            updateThisAboutMe.UpdatedDate = DateTime.Now;
            updateThisAboutMe.Description = model?.Description;
            updateThisAboutMe.FileKey = model?.FileKey;
            updateThisAboutMe.Name = model?.Name;
            updateThisAboutMe.Surname = model?.Surname;

            _aboutMeRepository.Update(updateThisAboutMe);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Update("Hakkımda"));

        }
    }
}
