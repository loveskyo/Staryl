using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staryl.IDAL
{
    public interface ISMSHelper
    {
        string SendSMS(string mobile, string message);
    }
}
