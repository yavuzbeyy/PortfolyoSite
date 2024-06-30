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
    public class ArticleService : IArticleService
    {

        private readonly IGenericRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IGenericRepository<Article> articleRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IResponse<string> Create(ArticleCreate model)
        {
            var newArticle = Article.FactoryMethod(model);

            if (newArticle == null)
            {
                return new ErrorResponse<string>(Messages.SaveError("Makale"));
            }

            _articleRepository.AddAsync(newArticle);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Save("Makale"));
        }

        public IResponse<string> Delete(int id)
        {
            var deleteThisArticle = _articleRepository.GetByIdAsync(id).Result;

            if (deleteThisArticle == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Makale"));
            }

            _articleRepository.Delete(deleteThisArticle);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Delete("Makale"));
        }

        public IResponse<IEnumerable<ArticleQuery>> GetArticleByArticleName(string articleName)
        {
            var article = _articleRepository.GetAll().Where(a => a.Title == articleName).FirstOrDefault();

            if (article == null)
            {
                return new ErrorResponse<IEnumerable<ArticleQuery>>(Messages.NotFound("Makale"));
            }

            var articleQuery = _mapper.Map<IEnumerable<ArticleQuery>>(article);

            return new SuccessResponse<IEnumerable<ArticleQuery>>(articleQuery);
        }

        public IResponse<IEnumerable<ArticleQuery>> ListAll()
        {
            var articles = _articleRepository.GetAll().ToList();

            if (articles == null || !articles.Any())
            {
                return new ErrorResponse<IEnumerable<ArticleQuery>>(Messages.NotFound("Makale"));
            }

            var articleQueries = _mapper.Map<IEnumerable<ArticleQuery>>(articles);

            return new SuccessResponse<IEnumerable<ArticleQuery>>(articleQueries);
        }

        public IResponse<string> Update(ArticleUpdate model)
        {
            var updateThisArticle = _articleRepository.GetByIdAsync(model.Id).Result;

            if (updateThisArticle == null)
            {
                return new ErrorResponse<string>(Messages.NotFound("Makale"));
            }

            updateThisArticle.Title = model?.Title;
            updateThisArticle.Content = model?.Content;
            updateThisArticle.FileKey = model?.FileKey;
            updateThisArticle.UpdatedDate = DateTime.Now;

            _articleRepository.Update(updateThisArticle);
            _unitOfWork.Commit();

            return new SuccessResponse<string>(Messages.Update("Makale"));
        }
    }
}
