using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DaijinSchool.Models
{
    public partial class UserDB
    {
        public string FIO { get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            } 
        }
    }
}
