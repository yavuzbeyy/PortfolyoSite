using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.DTOs
{
    public class ArticleDTO
    {
        
    }

    public class ArticleCreate
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? FileKey { get; set; }
    }

    public class ArticleUpdate
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? FileKey { get; set; }
    }

    public class ArticleQuery
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? FileKey { get; set; }
    }
}
