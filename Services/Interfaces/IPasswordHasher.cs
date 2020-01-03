namespace TuringEcommerce.Services.Interfaces
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
    }
}