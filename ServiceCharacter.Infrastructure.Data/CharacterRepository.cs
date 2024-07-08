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
            string query = $"UPDATE users SET user_character=@user_character WHERE user_login=@user_login";
            using MySqlCommand insertCommand = new(query);

            try
            {
                string characterJSON = JsonConvert.SerializeObject(character) ?? throw new ServerException(Server.ErrorSerializeCharacter);

                insertCommand.Parameters.AddWithValue("@user_character", characterJSON);

                insertCommand.Parameters.AddWithValue("@user_login", user.Name);

                MySQL.MySQL.Query(insertCommand);
            }
            catch
            {
                throw;
            }
        }

        public Character GetCharacter(User user)
        {
            string query = $"SELECT user_character FROM users WHERE user_login=@user_login";
            using MySqlCommand command = new(query);
            command.Parameters.AddWithValue("@user_login", user.Name);

            Character Character = user.Character;

            try
            {
                DataTable? dt = MySQL.MySQL.QueryRead(command) ?? throw new ServerException(Server.UserWasNotFound);

                string? characterString=null;
                foreach (DataRow row in dt.Rows)
                {
                    characterString = row["user_character"]?.ToString();
                }

                if (characterString == null) throw new ServerException(Server.InvalidCharacterData);

                Character = JsonConvert.DeserializeObject<Character>(characterString) ?? throw new ServerException(Server.ErrorDeserializeCharacter);
                return Character;
            }
            catch 
            {
                throw;
            } 
        }
    }
}
