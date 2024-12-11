using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels;

public class UserViewModel
{
	public string Fullname { get; private set; }
	public string Email { get; private set; }

	public UserViewModel(string fullname, string email)
	{
		Fullname = fullname;
		Email = email;
	}
}