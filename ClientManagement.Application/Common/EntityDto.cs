using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Common
{
    public abstract class EntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public abstract class EntityDto : EntityDto<int>
    {

    }
}
