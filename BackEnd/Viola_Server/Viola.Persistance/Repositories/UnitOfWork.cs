﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Repositories;
using Viola.Persistance.DBContext;

namespace Viola.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViolaContext _context;
        public IUserRepository User { get; }

        public IUserTokenRepository UserToken { get; }

        public UnitOfWork(ViolaContext context, IUserRepository user, IUserTokenRepository userToken)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserToken = userToken;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
