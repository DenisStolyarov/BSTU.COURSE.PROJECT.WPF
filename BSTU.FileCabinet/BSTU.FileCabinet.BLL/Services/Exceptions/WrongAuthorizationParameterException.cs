using System;

namespace BSTU.FileCabinet.BLL.Services.Exceptions
{
    public class WrongAuthorizationParameterException : Exception
    {
        private string message;

        public string WrongMessage
        {
            get { return message ?? string.Empty; }
        }

        private string parameter;

        public string WrongParameter
        {
            get { return parameter ?? string.Empty; }
        }


        public WrongAuthorizationParameterException(string message = null, string parameter = null)
        {
            this.message = message ?? message.Trim();
            this.parameter = parameter ?? parameter.Trim();
        }
    }
}
