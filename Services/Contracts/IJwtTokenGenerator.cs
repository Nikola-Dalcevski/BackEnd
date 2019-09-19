using DomainModels.Models;

namespace BusinessLayer.Contracts
{
    public interface IJwtTokenGenerator
    {
        string Generator(User user);
    }
}
