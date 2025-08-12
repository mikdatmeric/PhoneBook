using ReportService.Application.Abstract.Persistence.Repositories;
using ReportService.Domain.Entities;
using ReportService.Infrastructure.Abstract.Repositories;
using ReportService.Infrastructure.Concrete.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Concrete.Persistence.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(ReportServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
