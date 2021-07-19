using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Data
{
    public class RestauranteMVCContext : DbContext
    {
        public RestauranteMVCContext (DbContextOptions<RestauranteMVCContext> options)
            : base(options)
        {
        }

        public DbSet<RestauranteMVC.Models.Favorecidos> Favorecidos { get; set; }
    }
}
