using OWSData.Models.Composites;
using OWSData.Models.StoredProcs;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using SoulwalkerPublicAPI.Requests.EnumChecks;

namespace SoulwalkerPublicAPI.Requests.Users
{
    public class AddOrUpdateCustomCharacterDataCustomizationRequest
    {
        /// <summary>
        /// User Session GUID
        /// </summary>
        /// <remarks>
        /// This is a valid UserSessionGUID that contains the CharacterName we need to update.
        /// </remarks>
        public Guid UserSessionGUID { get; set; }
        /// <summary>
        /// AddOrUpdateCustomCharacterData
        /// </summary>
        /// <remarks>
        /// This is the Custom Character Data to uppdate.
        /// </remarks>
        public AddOrUpdateCustomCharacterData addOrUpdateCustomCharacterData { get; set; }


        private SuccessAndErrorMessage output;
        private Guid customerGUID;
        private ICharactersRepository charactersRepository;
        private IUsersRepository usersRepository;

        public void SetData(ICharactersRepository charactersRepository, IUsersRepository usersRepository, IHeaderCustomerGUID customerGuid)
        {
            this.charactersRepository = charactersRepository;
            this.usersRepository = usersRepository;
            customerGUID = customerGuid.CustomerGUID;
        }
         
        public async Task<SuccessAndErrorMessage> Handle()
        {

            MaleHumanCharacterCustomizationOptions HumanData = new MaleHumanCharacterCustomizationOptions();
            string[] subs = addOrUpdateCustomCharacterData.FieldValue.Split("|");
            int index = 0;

            // !!!!!!!!!!!!!!!!
            // Später noch nach unterschiedlicher Rasse checken mit unterschiedlichen Customization Optinen
            // !!!!!!!!!!!!!!!!!!!

            // Check Amount of Values
            // 9 Values
            if (subs.Length != 9)
            {
                return new SuccessAndErrorMessage()
                {
                    Success = false,
                    ErrorMessage = "Invalid Length"
                };
            }

            // Check Values
            foreach (string sub in subs)
            {
                if (!HumanData.CheckOptionAtIndex(index, sub))
                {
                    return new SuccessAndErrorMessage()
                    {
                        Success = false,
                        ErrorMessage = "Invalid Input Values"
                    };
                }
                index++;
            }

            // User Session Character Check
            var allCharactersInTheUserSession = await usersRepository.GetAllCharacters(customerGUID, UserSessionGUID);

            bool didWeFindTheCharacter = false;

            foreach (var currentCharacter in allCharactersInTheUserSession)
            {
                if (currentCharacter.CharName == addOrUpdateCustomCharacterData.CharacterName)
                {
                    didWeFindTheCharacter = true;
                }
            }

            // Did not find the Character -> Error
            if (!didWeFindTheCharacter)
            {
                return new SuccessAndErrorMessage()
                {
                    Success = false,
                    ErrorMessage = "Could not find the Character Name"
                };
            }

            // Output Variable
            output = new SuccessAndErrorMessage();


            // Update
            await charactersRepository.AddOrUpdateCustomCharacterData(customerGUID, addOrUpdateCustomCharacterData);

            // Output
            output.Success = true;
            output.ErrorMessage = "";

            return output;
        }
    }
}
