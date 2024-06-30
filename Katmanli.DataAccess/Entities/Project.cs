using Katmanli.Core.BaseEntity;
using Katmanli.DataAccess.DTOs;
using Microsoft.EntityFrameworkCore.Metadata;
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

        public static Project FactoryMethod(ProjectCreate project)
        {
            return new Project
            {
                ProjectName = project.ProjectName,
                Description = project.Description,
                FileKey = project.FileKey
            };
        }
    }
}
