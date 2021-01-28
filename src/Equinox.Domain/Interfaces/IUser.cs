using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
namespace Equinox.Domain.Interfaces
{
    public interface IUser
    {
        string Nome { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
