using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ServiceCharacter.Domain.Core;
using ServiceCharacter.Domain.Interfaces;
using ServiceCharacter.Infrastructure.Data.Exceptions;
using System.Data;


namespace ServiceCharacter.Infrastructure.Data
{
    public class CharacterRepository : ICharacterRepository
    {
        public void Create(User user, Character character)
        {
            const string query = $"UPDATE users SET user_character=@user_character WHERE user_login=@user_login";
            using MySqlCommand insertCommand = new(query);

            try
            {
                var CharacterJson = JsonConvert.SerializeObject(character) ?? throw new ServerException(Server.ErrorSerializeCharacter);

                insertCommand.Parameters.AddWithValue("@user_character", CharacterJson);
                insertCommand.Parameters.AddWithValue("@user_login", user.Name);

                MySql.MySql.Query(insertCommand);
            }
            catch
            {
                throw;
            }
        }

        public Character GetCharacter(User user)
        {
            const string query = $"SELECT user_character FROM users WHERE user_login=@user_login";
            using MySqlCommand command = new(query);
            command.Parameters.AddWithValue("@user_login", user.Name);

            

            try
            {
                var dt = MySql.MySql.QueryRead(command) ?? throw new ServerException(Server.UserWasNotFound);

                string? characterString=null;
                foreach (DataRow row in dt.Rows)
                {
                    characterString = row["user_character"]?.ToString();
                }

                if (characterString == null) throw new ServerException(Server.InvalidCharacterData);
                
                return JsonConvert.DeserializeObject<Character>(characterString) ?? throw new ServerException(Server.ErrorDeserializeCharacter);
            }
            catch 
            {
                throw;
            } 
        }
    }
}
