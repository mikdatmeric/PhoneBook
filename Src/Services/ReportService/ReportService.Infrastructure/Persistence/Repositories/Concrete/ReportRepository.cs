using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.Context;
using ReportService.Infrastructure.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Persistence.Repositories.Concrete
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(ReportServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
