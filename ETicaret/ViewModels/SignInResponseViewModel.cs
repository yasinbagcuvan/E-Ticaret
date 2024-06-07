using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SignInResponseViewModel
    {
        public List<UserClaimViewModel> Claims { get; set; }
        public string JwtToken { get; set; }
    }
}
