using Microsoft.EntityFrameworkCore;
using Task_App_ACS.Models;

namespace Task_App_ACS.Data
{
	public class APPDBCONTEXT : DbContext
	{
		public APPDBCONTEXT(DbContextOptions options) : base(options)
		{
		}

		protected APPDBCONTEXT()
		{
		}

		public DbSet<User> Users { get; set; }
	}
}
