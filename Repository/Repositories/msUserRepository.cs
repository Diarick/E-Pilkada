using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class msUserRepository
    {
        private E_VotingEntities _context;
        public msUserRepository(E_VotingEntities dealershipContext)
        {
            this._context = dealershipContext;
        }

        public void Delete(int id)
        {
            msUser data = _context.msUsers.Find(id);
            _context.msUsers.Remove(data);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public msUser GetDataByID(int id)
        {
            return _context.msUsers.Find(id);
        }

        public IQueryable<msUser> GetData()
        {
            return _context.msUsers;
        }

        public void Insert(msUser data)
        {
            _context.msUsers.Add(data);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(msUser data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
