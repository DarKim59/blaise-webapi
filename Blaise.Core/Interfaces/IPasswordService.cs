using System;
using System.Security;

namespace Blaise.Core.Interfaces
{
    public interface IPasswordService
    {
        SecureString CreateSecurePassword(string password);
    }
}
