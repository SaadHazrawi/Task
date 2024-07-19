using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.common.filter
{
    public class BookFilterDto
    {
        public string Name { get; set; }
        public DateTime? PublishDateFrom { get; set; }
        public DateTime? PublishDateTo { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AuthorId { get; set; }
    }
}
