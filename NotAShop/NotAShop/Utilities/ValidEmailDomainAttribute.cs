﻿using System.ComponentModel.DataAnnotations;

namespace NotAShop.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string ALLOWEDDOMAIN;
        public ValidEmailDomainAttribute(string allowedDomain)
        {
            ALLOWEDDOMAIN = allowedDomain;
        }
    }
}