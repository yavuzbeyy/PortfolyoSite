using Katmanli.Core.Response;
using Katmanli.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Interfaces
{
    public interface IProjectService
    {
        IResponse<IEnumerable<ProjectQuery>> ListAll();
        IResponse<string> Update(ProjectUpdate model);
        IResponse<string> Create(ProjectCreate model);
        IResponse<string> Delete(int id);
    }
}
