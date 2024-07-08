﻿using Newtonsoft.Json;
using ServiceCharacter.Domain.Core;
using ServiceCharacter.Infrastructure.Data;
using ServiceCharacter.Infrastructure.Data.Exceptions;
using ServiceCharacter.Services.Interfaces;

namespace ServiceCharacter.Infrastructure.Business
{
    public class ServiceCharacter : IServiceCharacter
    {
        private User User { get; set; }
        private CharacterRepository CharacterRepository { get; set; }
        public ServiceCharacter(User user) 
        {
            this.User = user;
            this.CharacterRepository = new CharacterRepository();
        }

        public void Start(User user)
        {
            // Телепортировать игрока на сцену для создания/редактирования персонажа
            try
            {
                Character Character = CharacterRepository.GetCharacter(user);
                user.Character = Character;
            }
            catch
            {
                throw;
            }
        }
        public void Create(User user, Character character)
        {
            try 
            {
                CharacterRepository.Create(user, character);
                user.Character = character;
            }
            catch 
            {
                throw;
            }
        }

        public void Update(User user)
        {
            try
            {
                Character character = CharacterRepository.GetCharacter(user);
                user.Character = character;
            }
            catch
            {
                throw;
            }
        }
    }
}
