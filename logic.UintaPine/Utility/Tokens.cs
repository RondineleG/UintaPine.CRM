﻿using System;
using System.Collections.Generic;
using System.Text;

namespace logic.UintaPine.Utility
{
    public interface IToken
    {
        DateTime Expiration { get; set; }
        string UserId { get; set; }
    }


    public class PasswordRecoveryToken : IToken
    {
        public DateTime Expiration { get; set; } = DateTime.Now;
        public string UserId { get; set; }
    }
}