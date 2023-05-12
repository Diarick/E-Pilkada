using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class msNIKRepository
    {
        private E_VotingEntities _context;
        public msNIKRepository(E_VotingEntities dealershipContext)
        {
            this._context = dealershipContext;
        }

        public void Delete(int id)
        {
            msNIK data = _context.msNIKs.Find(id);
            _context.msNIKs.Remove(data);
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

        public msNIK GetDataByID(int id)
        {
            return _context.msNIKs.Find(id);
        }

        public IQueryable<msNIK> GetData()
        {
            return _context.msNIKs;
        }

        public void Insert(msNIK data)
        {
            _context.msNIKs.Add(data);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(msNIK data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
