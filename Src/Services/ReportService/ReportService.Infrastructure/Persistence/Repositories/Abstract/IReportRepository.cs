﻿using PhoneBook.Core.Abstractions.Repositories;
using ReportService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Persistence.Repositories.Abstract
{
    public interface IReportRepository : IRepository<Report>
    {
    }
}
