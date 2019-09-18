using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts
{
    public interface IJwtTokenGenerator
    {
        string Generator(User user);
    }
}
