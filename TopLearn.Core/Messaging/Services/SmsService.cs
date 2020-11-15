using System;
using System.Collections.Generic;
using System.Text;
using Kavenegar;
using Microsoft.Extensions.Configuration;
using TopLearn.Core.messaging.Interfaces;

namespace TopLearn.Core.messaging.Services
{
    public class SmsService : IMessaging
    {
        private IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Send(string to, string subject, string message)
        {
            try
            {
                var smsApikey = _configuration.GetValue<String>("SmsApiKey");

                var sender = _configuration.GetValue<String>("SenderSms");

                var api = new KavenegarApi(smsApikey);

                api.Send(sender, to, message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }


        }
    }
}
