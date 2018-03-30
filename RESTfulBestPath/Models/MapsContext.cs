using Microsoft.EntityFrameworkCore;
using System;

namespace RESTfulBestPath.Models
{
	public class MapsContext : DbContext
    {
		public MapsContext(DbContextOptions<MapsContext> options)
			:base(options)
        {
        }
		public DbSet<NodeMap> MapsDB { get; set; }
    }
}
