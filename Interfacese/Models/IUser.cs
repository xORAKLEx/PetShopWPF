using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacese.Models
{
    public interface IUser
    {
        int id { get; }

        UserType type { get; }

        string name { get; }
    }
}
