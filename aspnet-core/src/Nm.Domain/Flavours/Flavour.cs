﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Nm.Flavours {
    public class Flavour : Entity<Guid> {
        public string Name { get; set; }

    
    }
}
