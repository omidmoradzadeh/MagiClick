using System;
using MagiClick.Application.Common.Interfaces;

namespace MagiClick.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
