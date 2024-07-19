using Application.Common;
using Application.Common.Dtos.Book;
using Application.Common.Dtos.Category;
using Application.Interface.UnitOfWork;
using AutoMapper;
using Core.common;
using Core.Model;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoreyServices : ICategoreyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoreyServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category> Add(CategoreyAddDto categoreyAdd)
        {
             if(categoreyAdd is null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Invliad data input");
            }
           var catorey=_mapper.Map<Category>(categoreyAdd);
           await _unitOfWork.Category.AddAsync(catorey);
            await _unitOfWork.SaveChangesAsync();
            return catorey;
        }

        public async Task<Pagination<CategoryResponseDTO>> GetAll(int pageIndex, int pageSize)
        {
            if (pageSize <= 0 || pageSize > 50)
            {
                pageSize = 50;
            }
            var catogries = await _unitOfWork.Category.ToPagination(pageIndex, pageSize,
                asNoTracking: true,
                where: null,
                orderBy: b => b.Id,
                orderByDescending: true,
                includes:null);
            if (catogries is null || catogries.Items.Count == 0)
            {
                throw new APIException(HttpStatusCode.NotFound, "No Cateogires found.");
            }
            var catogriesDtoPagination = new Pagination<CategoryResponseDTO>
            {
                PageIndex = catogries.PageIndex,
                PageSize = catogries.PageSize,
                TotalItemsCount = catogries.TotalItemsCount,
                Items = _mapper.Map<List<CategoryResponseDTO>>(catogries.Items)
            };

            return catogriesDtoPagination;
        }
    }
}
