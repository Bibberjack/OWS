using OWSData.Models.Composites;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using System.Threading.Tasks;
using System;
using OWSData.Models.StoredProcs;

namespace SoulwalkerPublicAPI.Requests.Users
{
    public class TestUpdateCharacterStrengthAndAgilityRequest
    {
        /// <summary>
        /// User Session GUID
        /// </summary>
        /// <remarks>
        /// This is a valid UserSessionGUID that contains the CharacterName we need to update.
        /// </remarks>
        public Guid UserSessionGUID { get; set; }
        /// <summary>
        /// Character Name
        /// </summary>
        /// <remarks>
        /// This is the name of the character to update.
        /// </remarks>
        public string CharacterName { get; set; }
        /// <summary>
        /// Strength
        /// </summary>
        /// <remarks>
        /// This is the Strength value to update.
        /// </remarks>
        public float Strength { get; set; }
        /// <summary>
        /// Agility
        /// </summary>
        /// <remarks>
        /// This is the Agility value to update.
        /// </remarks>
        public float Agility { get; set; }

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
                // Value Check
                if (Strength + Agility != 20)
                {
                    return new SuccessAndErrorMessage()
                    {
                        Success = false,
                        ErrorMessage = "Invalid Input Values"
                    };
                }

                // User Session Character Check
                var allCharactersInTheUserSession = await usersRepository.GetAllCharacters(customerGUID, UserSessionGUID);

                bool didWeFindTheCharacter = false;

                foreach (var currentCharacter in allCharactersInTheUserSession)
                {
                    if (currentCharacter.CharName == CharacterName)
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
                
                // Current Character
                GetCharByCharName charByCharName = await charactersRepository.GetCharByCharName(customerGUID, CharacterName);

                

                // New Character Stats to Update
                UpdateCharacterStats updateCharacterStats= new UpdateCharacterStats();

                // Update New Values
                updateCharacterStats.Strength = Strength;
                updateCharacterStats.Agility = Agility;
                
                // Get and Add Old Values
                updateCharacterStats.Acrobatics = (float)charByCharName.Acrobatics;
                updateCharacterStats.Alignment = (float)charByCharName.Alignment;
                updateCharacterStats.AttackPower = (float)charByCharName.AttackPower;
                updateCharacterStats.AttackSpeed = (float)charByCharName.AttackSpeed;
                updateCharacterStats.Avoidance = (float)charByCharName.Avoidance;
                updateCharacterStats.BaseAttack= (float)charByCharName.BaseAttack;
                updateCharacterStats.BaseAttackBonus= (float)charByCharName.BaseAttackBonus;
                updateCharacterStats.BonusArmor = (float)charByCharName.BonusArmor;
                updateCharacterStats.CharacterLevel = charByCharName.CharacterLevel;
                updateCharacterStats.Charisma = (float)charByCharName.Charisma;
                updateCharacterStats.CharName = charByCharName.CharName;
                updateCharacterStats.Climb = (float)charByCharName.Climb;
                updateCharacterStats.Constitution = (float)charByCharName.Constitution;
                updateCharacterStats.Copper = charByCharName.Copper;
                updateCharacterStats.CritChance = (float)charByCharName.CritChance;
                updateCharacterStats.CritMultiplier = (float)charByCharName.CritMultiplier;
                updateCharacterStats.CustomerGUID = charByCharName.CustomerGuid.ToString();
                updateCharacterStats.Defense = (float)charByCharName.Defense;
                updateCharacterStats.Description = charByCharName.Description;
                updateCharacterStats.Dexterity = (float)charByCharName.Dexterity;
                updateCharacterStats.Dodge = (float)charByCharName.Dodge;
                updateCharacterStats.Endurance = (float)charByCharName.Endurance;
                updateCharacterStats.EnduranceRegenRate = (float)charByCharName.EnduranceRegenRate;
                updateCharacterStats.Energy = (float)charByCharName.Energy;
                updateCharacterStats.EnergyRegenRate = (float)charByCharName.EnergyRegenRate;
                updateCharacterStats.Fame = (float)charByCharName.Fame;
                updateCharacterStats.Fatigue = (float)charByCharName.Fatigue;
                updateCharacterStats.FatigueRegenRate = (float)charByCharName.FatigueRegenRate;
                updateCharacterStats.ForceArmor = (float)charByCharName.ForceArmor;
                updateCharacterStats.Fortitude = (float)charByCharName.Fortitude;
                updateCharacterStats.FreeCurrency = charByCharName.FreeCurrency;
                updateCharacterStats.Gender = charByCharName.Gender;
                updateCharacterStats.Gold = charByCharName.Gold;
                updateCharacterStats.Haste = (float)charByCharName.Haste;
                updateCharacterStats.Health = (float)charByCharName.Health;
                updateCharacterStats.HealthRegenRate = (float)charByCharName.HealthRegenRate;
                updateCharacterStats.HitDie = charByCharName.HitDie;
                updateCharacterStats.Hunger = (float)charByCharName.Hunger;
                updateCharacterStats.Initiative = (float)charByCharName.Initiative;
                updateCharacterStats.Intellect = (float)charByCharName.Intellect;
                updateCharacterStats.Magic = (float)charByCharName.Magic;
                updateCharacterStats.MagicArmor = (float)charByCharName.MagicArmor;
                updateCharacterStats.Mana = (float)charByCharName.Mana;
                updateCharacterStats.ManaRegenRate = (float)charByCharName.ManaRegenRate;
                updateCharacterStats.MaxEndurance = (float)charByCharName.MaxEndurance;
                updateCharacterStats.MaxEnergy = (float)charByCharName.MaxEnergy;
                updateCharacterStats.MaxFatigue = (float)charByCharName.MaxFatigue;
                updateCharacterStats.MaxHealth = (float)charByCharName.MaxHealth;
                updateCharacterStats.MaxMana = (float)charByCharName.MaxMana;
                updateCharacterStats.MaxStamina = (float)charByCharName.MaxStamina;
                updateCharacterStats.Multishot = (float)charByCharName.Multishot;
                updateCharacterStats.NaturalArmor = (float)charByCharName.NaturalArmor;
                updateCharacterStats.Parry = (float)charByCharName.Parry;
                updateCharacterStats.Perception = (float)charByCharName.Perception;
                updateCharacterStats.PhysicalArmor = (float)charByCharName.PhysicalArmor;
                updateCharacterStats.PremiumCurrency = charByCharName.PremiumCurrency;
                updateCharacterStats.Range = (float)charByCharName.Range;
                updateCharacterStats.Reflex = (float)charByCharName.Reflex;
                updateCharacterStats.ReloadSpeed = (float)charByCharName.ReloadSpeed;
                updateCharacterStats.Resistance = (float)charByCharName.Resistance;
                updateCharacterStats.RX = (float)charByCharName.Rx;
                updateCharacterStats.RY = (float)charByCharName.Ry;
                updateCharacterStats.RZ= (float)charByCharName.Rz;
                updateCharacterStats.Score = charByCharName.Score;
                updateCharacterStats.Silver = charByCharName.Silver;
                updateCharacterStats.Size = charByCharName.Size;
                updateCharacterStats.Speed = (float)charByCharName.Speed;
                updateCharacterStats.SpellPenetration = (float)charByCharName.SpellPenetration;
                updateCharacterStats.SpellPower = (float)charByCharName.SpellPower;
                updateCharacterStats.Spirit = (float)charByCharName.Spirit;
                updateCharacterStats.Stamina = (float)charByCharName.Stamina;
                updateCharacterStats.StaminaRegenRate = (float)charByCharName.StaminaRegenRate;
                updateCharacterStats.Stealth = (float)charByCharName.Stealth;
                updateCharacterStats.TeamNumber = charByCharName.TeamNumber;
                updateCharacterStats.Thirst = (float)charByCharName.Thirst;
                updateCharacterStats.Versatility = (float)charByCharName.Versatility;
                updateCharacterStats.Weight = (float)charByCharName.Weight;
                updateCharacterStats.Willpower = (float)charByCharName.Willpower;
                updateCharacterStats.Wisdom = (float)charByCharName.Wisdom;
                updateCharacterStats.Wounds = (float)charByCharName.Wounds;
                updateCharacterStats.X = (float)charByCharName.X;
                updateCharacterStats.XP = charByCharName.Xp;
                updateCharacterStats.Y = (float)charByCharName.Y;
                updateCharacterStats.Z = (float)charByCharName.Z;


            // Send new Character Stats
            await charactersRepository.UpdateCharacterStats(updateCharacterStats);

                // Output
                output.Success = true;
                output.ErrorMessage = "";

                return output;
            }
        }
}
