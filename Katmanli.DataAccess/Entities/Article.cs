﻿using Katmanli.Core.BaseEntity;
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
    }
}
