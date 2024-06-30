using Katmanli.Core.Response;
using Katmanli.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IArticleService
    {
        IResponse<IEnumerable<ArticleQuery>> ListAll();
        public IResponse<string> Update(ArticleUpdate model);
        IResponse<string> Create(ArticleCreate model);
        IResponse<string> Delete(int id);
        IResponse<IEnumerable<ArticleQuery>> GetArticleByArticleName(string articleName);
    }
}
