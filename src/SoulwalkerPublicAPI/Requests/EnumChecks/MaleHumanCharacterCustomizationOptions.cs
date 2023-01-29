using System;

namespace SoulwalkerPublicAPI.Requests.EnumChecks
{
    public class MaleHumanCharacterCustomizationOptions
    {
        // Check String in Enum:
        // Enum.IsDefined(typeof(Age), youragevariable)
        // if (!TestEnum.TryParse(enumName, out enumValue))


        enum HairTyps
        {
            None,
            SK_Hu_M_Hair_01,
            SK_Hu_M_Hair_02,
            SK_Hu_M_Hair_03,
            SK_Hu_M_Hair_04,
            SK_Hu_M_Hair_05
        }

        enum HairColors
        {
            MI_Hair_01_Bd,
            MI_Hair_01_Bk,
            MI_Hair_01_Br,
            MI_Hair_01_Gr,
            MI_Hair_02_Bd,
            MI_Hair_02_Bk,
            MI_Hair_02_Br,
            MI_Hair_02_Gr
        }

        enum Facial02Typs
        {
            None,
            SK_Hu_M_Beard_01,
            SK_Hu_M_Beard_02,
            SK_Hu_M_Beard_03,
            SK_Hu_M_Beard_04,
            SK_Hu_M_Beard_05,
            SK_Hu_M_Beard_06
        }

        enum Facial01Typs
        {
            None,
            SK_Hu_M_Brows_01,
            SK_Hu_M_Brows_02,
            SK_Hu_M_Brows_03,
            SK_Hu_M_Brows_04
        }

        enum FacialColors
        {
            MI_HuM_Facials_Bd,
            MI_HuM_Facials_Bk,
            MI_HuM_Facials_Br,
            MI_HuM_Facials_Gr
        }
        enum EyeColors
        {
            MI_Eye_Bl,
            MI_Eye_Br,
            MI_Eye_Gn,
            MI_Eye_Pe
        }

        enum HeadColors
        {
            MI_HuM_Head_01_A,
            MI_HuM_Head_02_A,
            MI_HuM_Head_03_A,
            MI_HuM_Head_04_A,
            MI_HuM_Head_05_A,
        }

        enum BodyColors
        {
            MI_HuM_Body_01,
            MI_HuM_Body_02,
            MI_HuM_Body_03,
            MI_HuM_Body_04,
            MI_HuM_Body_05
        }

        public bool CheckOptionAtIndex(int index, string name)
        {
            switch (index)
            {
                case 0:
                    return CheckHairtyp(name);
                case 1:
                    return CheckHairColor(name);
                case 2:
                    return CheckFacial02typ(name);
                case 3:
                    return CheckFacialColor(name);
                case 4:
                    return CheckFacial01typ(name);
                case 5:
                    return CheckFacialColor(name);
                case 6:
                    return CheckEyeColor(name);
                case 7:
                    return CheckHeadColor(name);
                case 8:
                    return CheckBodyColor(name);
                default:
                    return false;
            }
        }

        // Hair Typ check
        private bool CheckHairtyp(string hairtyp)
        {
            if (!HairTyps.TryParse(hairtyp, out HairTyps a))
            {
                return false;
            }
            return true;
        }

        // Hair Colors check
        private bool CheckHairColor(string haircolor)
        {
            if (!HairColors.TryParse(haircolor, out HairColors a))
            {
                return false;
            }
            return true;
        }

        // Facial02 Typ check
        private bool CheckFacial02typ(string facialtyp)
        {
            if (!Facial02Typs.TryParse(facialtyp, out Facial02Typs a))
            {
                return false;
            }
            return true;
        }

        // Facial01 Typ check
        private bool CheckFacial01typ(string facialtyp)
        {
            if (!Facial01Typs.TryParse(facialtyp, out Facial01Typs a))
            {
                return false;
            }
            return true;
        }

        // Facial Color check
        private bool CheckFacialColor(string facialcolor)
        {
            if (!FacialColors.TryParse(facialcolor, out FacialColors a))
            {
                return false;
            }
            return true;
        }

        // Eyel Color check
        private bool CheckEyeColor(string eyecolor)
        {
            if (!EyeColors.TryParse(eyecolor, out EyeColors a))
            {
                return false;
            }
            return true;
        }

        // Head Color check
        private bool CheckHeadColor(string headcolor)
        {
            if (!HeadColors.TryParse(headcolor, out HeadColors a))
            {
                return false;
            }
            return true;
        }

        // Body Colors check
        private bool CheckBodyColor(string bodycolor)
        {
            if (!BodyColors.TryParse(bodycolor, out BodyColors a))
            {
                return false;
            }
            return true;
        }
    }
}
