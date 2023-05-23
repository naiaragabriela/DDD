﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.Contracts.v1
{
    public interface IEntity : IEquatable<IEntity>
    {
        Guid Id { get; }
    }
}
