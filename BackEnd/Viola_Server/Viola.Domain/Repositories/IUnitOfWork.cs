﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viola.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IUserTokenRepository UserToken { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
