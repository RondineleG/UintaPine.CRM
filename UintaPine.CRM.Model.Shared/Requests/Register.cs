﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UintaPine.CRM.Model.Shared.Requests
{
    public class Register
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}