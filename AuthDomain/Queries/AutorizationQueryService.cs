using AuthDomain.Queries.Object;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries
{
    public class AutorizationQueryService : IQueryService<EntryDTO, Users?>
    {
        private readonly IAuthRepository _authRepository;

        public AutorizationQueryService(IAuthRepository authRepository)
        {
            ArgumentNullException.ThrowIfNull(authRepository);
            _authRepository = authRepository;
        }

        public Users? Execute(EntryDTO obj)
        {
            if (obj == null) return null;

            return _authRepository.Authorization(obj.Login, obj.Password);
        }
    }
}
