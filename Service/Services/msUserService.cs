using Model;
using Repository.Repositories;
using System.Linq;

namespace Service.Services
{
    public class msUserService
    {
        public msUser CheckUser(string email, string password)
        {
            using (E_VotingEntities ctx = new E_VotingEntities())
            {
                msUserRepository _repo = new msUserRepository(ctx);

                return _repo.GetData().Where(f => f.Email == email && f.Password == password).FirstOrDefault();
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
