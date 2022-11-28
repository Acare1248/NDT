using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebNDTIT01.Models.Workflows.ITRequestModels;

namespace WebNDTIT01.Interfaces
{
    public interface IWorkflowDbContext
    {
        DbSet<ApprovalData> ApprovalDatas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
