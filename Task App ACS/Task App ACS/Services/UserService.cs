using Microsoft.EntityFrameworkCore;
using Task_App_ACS.Data;
using Task_App_ACS.DTO;

namespace Task_App_ACS.Services
{
	public class UserService : IUserService
	{
		private readonly APPDBCONTEXT _context;

		public UserService(APPDBCONTEXT context)
		{
			_context = context;
		}

		public async Task<List<UserDTO>> SearchAsync(string term)
		{
			if (string.IsNullOrWhiteSpace(term))
				return new List<UserDTO>();

			return await _context.Users
				.AsNoTracking()
				.Where(c => EF.Functions.Like(c.Email, $"%{term}%") || EF.Functions.Like(c.PhoneNumber, $"%{term}%"))
				.Select(c => new UserDTO
				{
					Id = c.Id,
					Email = c.Email,
					PhoneNumber = c.PhoneNumber
				})
				.ToListAsync();
		}
	}
}
