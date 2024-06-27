using Katmanli.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class Project : BaseEntity
    {
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? FileKey { get; set; }
    }
}
