using AutoMapper;
using NbaApp.Data.Models.StatisticsModels;
using NbaApp.InternalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApp.InternalApi.Profiles
{
    public class SummaryProfile:Profile
    {
        public SummaryProfile()
        {
            CreateMap<CareerSummary, SummaryDto>();
            CreateMap<SummaryDto, CareerSummary>();
        }
    }
}
