using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Shared.Parameters;

namespace Blog.Server.Services
{
    public interface IVerificationService
    {
        Task<bool> GetVerificationCode(VerificationService_GetVerificationCodePara verificationService_GetVerificationCodePara);
    }
}
