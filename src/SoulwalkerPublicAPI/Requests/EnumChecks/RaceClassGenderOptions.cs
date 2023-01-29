namespace SoulwalkerPublicAPI.Requests.EnumChecks
{
    public class RaceClassGenderOptions
    {
        enum Races
        {
            Human,
            Bork,
            VariSha,
            Gorrakz,
            Stonlings
        }

        enum Classes
        {
            Soulwalker,
            Soulbinder,
            Magician
        }

        enum Gender
        {
            Male,
            Female,
            Divers
        }

        public bool CheckOptionAtIndex(int index, string name)
        {
            switch (index)
            {
                case 0:
                    return CheckRace(name);
                case 1:
                    return CheckClass(name);
                case 2:
                    return CheckGender(name);
                default:
                    return false;
            }
        }

        // Race Check
        private bool CheckRace(string race)
        {
            if (!Races.TryParse(race, out Races a))
            {
                return false;
            }
            return true;
        }

        // Class Check
        private bool CheckClass(string charClass)
        {
            if (!Classes.TryParse(charClass, out Classes a))
            {
                return false;
            }
            return true;
        }

        // Gender Check
        private bool CheckGender(string gender)
        {
            if (!Gender.TryParse(gender, out Gender a))
            {
                return false;
            }
            return true;
        }
    }
}