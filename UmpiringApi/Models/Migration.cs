﻿using System;
using System.Collections.Generic;

namespace UmpiringApi.Models
{
    public partial class Migration
    {
        public string Key { get; set; }
        public int SqlId { get; set; }
        public string MongoId { get; set; }
        public int SecondaryKey { get; set; }
    }
}
