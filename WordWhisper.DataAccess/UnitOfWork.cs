﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWhisper.Core;
using WordWhisper.Core.Repositories;
using WordWhisper.DataAccess.Concrete.EntityFramework.Contexts;
using WordWhisper.DataAccess.Repositories;

namespace WordWhisper.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WordWhisperContext _context;
        private UserRepository _userRepository;
        public UnitOfWork(WordWhisperContext context)
        {
            this._context = context;
        }
        public IUserRepository Users => 
            _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
