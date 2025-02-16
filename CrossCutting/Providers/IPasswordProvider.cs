namespace SMNPastel.Providers
{
    public interface IPasswordProvider
    {
        string GenerateSalt();
        string HashPassword(string password, string salt);
    }
}
