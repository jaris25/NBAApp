using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaApi.Models
{
    public class PlayersContext : DbContext
    {
        public DbSet<Standard> Players { get; set; }


    }
}
