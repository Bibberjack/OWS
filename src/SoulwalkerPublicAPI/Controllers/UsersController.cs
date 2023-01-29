using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OWSData.Models.Composites;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using SoulwalkerPublicAPI.Requests.Users;
using System.Threading.Tasks;

namespace SoulwalkerPublicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IHeaderCustomerGUID _customerGuid;

        public UsersController(ICharactersRepository charactersRepository, IUsersRepository usersRepository,
           IHeaderCustomerGUID customerGuid)
        {
            _charactersRepository = charactersRepository;
            _usersRepository = usersRepository;
            _customerGuid = customerGuid;
        }

        /// <summary>
        /// Test Update the Strength and Agility of a Character
        /// </summary>
        /// <remarks>
        /// Test Update the Strength and Agility of a Character specified by Character. We also require a valid UserSessionGUID
        /// </remarks>
        /// <param name="request">
        /// <b>CustomerGUID</b> - This is the API Key.<br/>
        /// <b>UserSessionGUID</b> - This is a valid UserSessionGUID that contains the CharacterName we need to update.<br/>
        /// <b>CharacterName</b> - This is the name of the character to update.<br/>
        /// <b>Strength</b> - This is the Strength value to update.
        ///  <b>Agility</b> - This is the Agility value to update.
        /// </param>
        [HttpPost]
        [Route("TestUpdateCharacterStrengthAndAgility")]
        [Produces(typeof(SuccessAndErrorMessage))]
        public async Task<SuccessAndErrorMessage> TestUpdateCharacterStrengthAndAgility([FromBody] TestUpdateCharacterStrengthAndAgilityRequest request)
        {
            request.SetData(_charactersRepository,_usersRepository, _customerGuid);
            return await request.Handle();
        }

        /// <summary>
        /// AddOrUpdateCustomCharacterDataCustomizationRequest
        /// </summary>
        /// <remarks>
        /// Add or Update CustomCharacterData for the Character Customization specified by Character. We also require a valid UserSessionGUID
        /// </remarks>
        /// <param name="request">
        /// <b>CustomerGUID</b> - This is the API Key.<br/>
        /// <b>UserSessionGUID</b> - This is a valid UserSessionGUID that contains the CharacterName we need to update.<br/>
        /// <b>AddOrUpdateCustomCharacterData</b> - This is the Value to update.
        /// </param>
        [HttpPost]
        [Route("AddOrUpdateCustomCharacterDataCustomization")]
        [Produces(typeof(SuccessAndErrorMessage))]
        public async Task<SuccessAndErrorMessage> AddOrUpdateCustomCharacterDataCustomization([FromBody] AddOrUpdateCustomCharacterDataCustomizationRequest request)
        {
            request.SetData(_charactersRepository, _usersRepository, _customerGuid);
            return await request.Handle();
        }

        /// <summary>
        /// AddOrUpdateRaceClassGenderRequest
        /// </summary>
        /// <remarks>
        /// Add or Update CustomCharacterData for the Race, Class and Gender specified by Character. We also require a valid UserSessionGUID
        /// </remarks>
        /// <param name="request">
        /// <b>CustomerGUID</b> - This is the API Key.<br/>
        /// <b>UserSessionGUID</b> - This is a valid UserSessionGUID that contains the CharacterName we need to update.<br/>
        /// <b>AddOrUpdateCustomCharacterData</b> - This is the Value of Race, Class and Gender to update.
        /// </param>
        [HttpPost]
        [Route("AddOrUpdateRaceClassGender")]
        [Produces(typeof(SuccessAndErrorMessage))]
        public async Task<SuccessAndErrorMessage> AddOrUpdateRaceClassGender([FromBody] AddOrUpdateRaceClassGenderRequest request)
        {
            request.SetData(_charactersRepository, _usersRepository, _customerGuid);
            return await request.Handle();
        }
    }
}
