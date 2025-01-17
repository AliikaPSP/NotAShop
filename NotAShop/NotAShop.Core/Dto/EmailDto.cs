﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAShop.Core.Dto
{
    public class EmailDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body {  get; set; } = string.Empty;
        public List<string> Attachments { get; set; } = new List<string>();

    }
}
