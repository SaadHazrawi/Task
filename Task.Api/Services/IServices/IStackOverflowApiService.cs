using Core.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IStackOverflowApiService
    {
        Task<List<StackOverflowPost>> GetLatestQuestionsAsync(int pageSize);
    }

}
