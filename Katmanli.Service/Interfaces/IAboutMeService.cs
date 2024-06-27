using Katmanli.Core.Response;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IAboutMeService
    {
        IResponse<IEnumerable<AboutMeQuery>> List();
        public IResponse<string> Update(AboutMeUpdate model);
        IResponse<string> Create(AboutMeCreate model);
        IResponse<string> Delete(int id);
    }
}
