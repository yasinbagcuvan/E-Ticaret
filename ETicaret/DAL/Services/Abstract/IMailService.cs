using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Abstract
{
    public interface IMailService
    {
        void Send(string email, string displayName, string subject, string body);
    }
}
