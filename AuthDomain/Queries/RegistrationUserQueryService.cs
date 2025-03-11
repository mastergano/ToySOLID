using AuthDomain.Queries.Object;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries
{
    public class RegistrationUserQueryService
              : IQueryService<RegistrationDTO, Users?>
    {
        private readonly IAuthRepository _authRepository;

        public RegistrationUserQueryService(IAuthRepository authRepository)
        {
            ArgumentNullException.ThrowIfNull(authRepository, nameof(authRepository));
            _authRepository = authRepository;
        }

        public Users? Execute(RegistrationDTO obj)
        {
            if (obj == null || !obj.Password.Equals(obj.PasswordAgain))
            {
                return null;
            }
            return _authRepository.Registration(obj.Login, obj.Password, obj.avatar);
        }
    }
}
