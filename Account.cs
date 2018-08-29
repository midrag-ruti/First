using System;
using System.Collections.Generic;
using System.Text;

namespace CreditGuard
{
    public class Account
    {
        public string CgGatewayUrl { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string TerminalId { get; set; }


        public Account(string cgGatewayUrl, string userId, string password, string terminalId)
        {
            CgGatewayUrl = cgGatewayUrl;
            UserId = userId;
            Password = password;
            TerminalId = terminalId;
        }
    }
}
