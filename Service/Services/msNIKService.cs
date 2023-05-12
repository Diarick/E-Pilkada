using Model;
using Repository.Repositories;
using System.Linq;

namespace Service.Services
{
    public class msNIKService
    {
        public msNIK CheckUser(string nik)
        {
            using (E_VotingEntities ctx = new E_VotingEntities())
            {
                msNIKRepository _repo = new msNIKRepository(ctx);

                msNIK Obj = new msNIK();
                Obj = _repo.GetData().Where(f => f.NIK == nik).FirstOrDefault();

                return Obj;
            }
        }

        public void Insert(msUser newUser)
        {
            using (E_VotingEntities ctx = new E_VotingEntities())
            {
                msUserRepository _repo = new msUserRepository(ctx);
                _repo.Insert(newUser);
                
                _repo.Save();
            }
        }
    }
}
