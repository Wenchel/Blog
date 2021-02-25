using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.DataTransferObjects
{
    public class VerificationService_GetVerificationCodeDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
