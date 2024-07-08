using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCharacter.Infrastructure.Data.Exceptions
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }

    public class Server
    {
        public static readonly string ServerIsNotAvaliable = "At the moment the server is unreachable";

        public static readonly string UserWasNotFound = "The user was not found";

        public static readonly string InvalidCharacterData = "A data of character for this user is invalid";

        public static readonly string ErrorSerializeCharacter = "Error in the process serialize of object character's";

        public static readonly string ErrorDeserializeCharacter = "Error in the process deserialize of JSON character's";
    }
}
