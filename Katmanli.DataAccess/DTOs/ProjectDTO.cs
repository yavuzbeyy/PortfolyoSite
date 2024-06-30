using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class ProjectDTO
    {
    }

    public class ProjectCreate
    {
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? FileKey { get; set; }
    }

    public class ProjectQuery
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? FileKey { get; set; }
    }

    public class ProjectUpdate
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? FileKey { get; set; }
    }
}
