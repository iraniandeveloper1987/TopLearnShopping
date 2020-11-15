using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.Core.messaging.Interfaces
{
  public  interface IMessaging
    {
         void Send( string to , string subject,string message);
    }
}
