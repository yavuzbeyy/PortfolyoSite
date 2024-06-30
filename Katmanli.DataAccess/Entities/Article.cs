using Katmanli.Core.BaseEntity;
using Katmanli.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class Article : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? FileKey { get; set; }

        public static Article FactoryMethod(ArticleCreate model)
        {
            Article article = new Article();

            article.Title = model?.Title;
            article.Content = model?.Content;
            article.FileKey = model?.FileKey;

            return article;
        }
    }
}
