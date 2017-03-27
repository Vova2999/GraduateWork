namespace GraduateWork.Server.Common.Database {
	public interface IDatabaseAuthorizer {
		bool UserIsCorrect(string login, string password);
		bool AccessIsAllowed(string login, string password, int requestedAccessType);
	}
}