namespace WebApi.Services
{
	public interface ITokenService
	{
		string CreateToken(string username);
	}
}
