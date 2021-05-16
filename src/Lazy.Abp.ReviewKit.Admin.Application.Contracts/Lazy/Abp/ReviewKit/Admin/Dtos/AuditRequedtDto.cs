using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.ReviewKit.Admin.Dtos
{
    public class AuditRequedtDto
    {
        public AuditStatus Status { get; set; }

        public string Remark { get; set; }
    }
}
