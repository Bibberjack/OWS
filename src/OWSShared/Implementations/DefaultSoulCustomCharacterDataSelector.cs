using OWSData.Models.Tables;
using OWSShared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWSShared.Implementations
{
    public class DefaultSoulCustomCharacterDataSelector : ISoulCustomCharacterDataSelector
    {
        // FieldNames that allowed
        enum PossibleFieldNames
        {
            Customization,
            CharInfo
        }

        // Check Field Names
        private bool CheckPossibleFieldNames(string fieldname)
        {
            if (!PossibleFieldNames.TryParse(fieldname, out PossibleFieldNames a))
            {
                return false;
            }
            return true;
        }

        // Check Input
        public bool ShouldExportThisCustomCharacterDataField(string fieldName)
        {
            if (CheckPossibleFieldNames(fieldName))
            {
                return true;
           }
            return false;
        }
    }
}
