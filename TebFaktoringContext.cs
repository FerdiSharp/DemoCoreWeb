using DemoCoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreWeb {

	public interface ITebFaktoringContext {
		DbSet<Site> Sites{ get; set; }
		Task<int> SaveChanges();
	}
	public class TebFaktoringContext : DbContext, ITebFaktoringContext {
		public TebFaktoringContext(DbContextOptions<TebFaktoringContext> options) : base(options) {

		}
		public DbSet<Site> Sites { get; set; }

		Task<int> ITebFaktoringContext.SaveChanges() {
			throw new NotImplementedException();
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		//	if (!optionsBuilder.IsConfigured) {
		//		optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;");
		//	}
		//}

		//protected override void OnModelCreating(ModelBuilder modelBuilder) {
		//}
	}
}

