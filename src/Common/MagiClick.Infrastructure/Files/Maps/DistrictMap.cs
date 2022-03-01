using System.Globalization;
using MagiClick.Application.Dto;
using CsvHelper.Configuration;

namespace MagiClick.Infrastructure.Files.Maps
{
    public sealed class DistrictMap : ClassMap<DistrictDto>
    {
        public DistrictMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Villages).Convert(_ => "");
        }
    }
}
