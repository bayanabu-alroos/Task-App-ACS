using Task_App_ACS.DTO;

namespace Task_App_ACS.Services
{
	public interface IUserService
	{
		Task<List<UserDTO>> SearchAsync(string searh);
	}
}
