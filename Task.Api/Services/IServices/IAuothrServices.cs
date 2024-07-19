using Application.Common.Dtos.Author;
using Application.Common.Dtos.SubCategory;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IAuthorServices
    {
        Task<Author> Add(AuthorAddDto authorAdd);

    }
}
