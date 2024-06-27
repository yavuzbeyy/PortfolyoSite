using Katmanli.Core.BaseEntity;
using Katmanli.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.DataAccess.Entities
{
    public class  AboutMe : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }
        public string? FileKey { get; set; }

        public static AboutMe FactoryMethod(AboutMeCreate model)
        {
            AboutMe aboutMe = new AboutMe();

            aboutMe.Name = model?.Name;
            aboutMe.Surname = model?.Surname;
            aboutMe.Description = model?.Description;
            aboutMe.FileKey = model?.FileKey;

            return aboutMe;
        }

    }
}
