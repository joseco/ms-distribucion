﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
        Task Commit();
    }
}
