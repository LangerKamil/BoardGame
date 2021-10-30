using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRental.Infrastructure.Repositories.Interfaces
{
    public interface IEmailRepository
    {
        public bool SendEmail(string addresses);
    }
}
