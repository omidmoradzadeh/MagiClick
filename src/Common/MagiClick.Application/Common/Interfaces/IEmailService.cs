using System.Threading.Tasks;
using MagiClick.Application.Common.Models;

namespace MagiClick.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
