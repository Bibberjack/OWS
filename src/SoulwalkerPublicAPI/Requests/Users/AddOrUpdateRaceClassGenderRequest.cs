using OWSData.Models.Composites;
using OWSData.Models.StoredProcs;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using SoulwalkerPublicAPI.Requests.EnumChecks;
using System.Threading.Tasks;
using System;

namespace SoulwalkerPublicAPI.Requests.Users
{
    public class AddOrUpdateRaceClassGenderRequest
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
        /// This is the Custom Character Data to uppdate. (Race)
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
            RaceClassGenderOptions RaceData= new RaceClassGenderOptions();
            string[] subs = addOrUpdateCustomCharacterData.FieldValue.Split("|");
            int index = 0;

            // Check Amount of Values
            // 3 Values
            if (subs.Length != 3)
            {
                return new SuccessAndErrorMessage()
                {
                    Success = false,
                    ErrorMessage = "Invalid Length"
                };
            }

            // Check: Is Value a Race
            foreach (string sub in subs)
            {
                if (!RaceData.CheckOptionAtIndex(index, sub))
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
