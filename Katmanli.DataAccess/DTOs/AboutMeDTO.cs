using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class AboutMeDTO
    {
    }
    public class AboutMeQuery
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Description { get; set; }
            public string? FileKey { get; set; }
        }

        public class AboutMeCreate
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Description { get; set; }
            public string? FileKey { get; set; }
        }

        public class AboutMeUpdate
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Description { get; set; }
            public string? FileKey { get; set; }
        }

    }

