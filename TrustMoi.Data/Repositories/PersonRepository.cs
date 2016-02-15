﻿using TrustMoi.Data.Base;
using TrustMoi.Data.Interfaces;

namespace TrustMoi.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext context) : base(context)
        {
        }
    }
}