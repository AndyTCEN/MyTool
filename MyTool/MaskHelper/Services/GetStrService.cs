using MaskHelper.Enum;

namespace MaskHelper.Services
{
    public class GetStrService : IGetStrService
    {
        public string GetAddrMask(string Addr)
        {
            return Addr.MaskStr(MaskTypeEnum.Addr);
        }

        public string GetBankAccountMask(string BankAccount)
        {
            return BankAccount.MaskStr(MaskTypeEnum.BankAccount);
        }

        public string GetBirthdayMask(string Birthday)
        {
            return Birthday.MaskStr(MaskTypeEnum.Birthday);
        }

        public string GetCellPhoneMask(string CellPhone)
        {
            return CellPhone.MaskStr(MaskTypeEnum.CellPhone);
        }

        public string GetCreditCardNumMask(string CreditCardNum)
        {
            return CreditCardNum.MaskStr(MaskTypeEnum.CreditCardNum);
        }

        public string GetEmailMask(string Email)
        {
            return Email.MaskStr(MaskTypeEnum.Email);
        }

        public string GetNameMask(string name)
        {
            return name.MaskStr(MaskTypeEnum.Name);
        }

        public string GetPassportIDMask(string PassportID)
        {
            return PassportID.MaskStr(MaskTypeEnum.PassportID);
        }

        public string GetPhoneMask(string Phone)
        {
            return Phone.MaskStr(MaskTypeEnum.Phone);
        }

        public string GetPolicyNumMask(string PolicyNum)
        {
            return PolicyNum.MaskStr(MaskTypeEnum.PolicyNum);
        }

        public string GeTWIDMask(string TWID)
        {
            return TWID.MaskStr(MaskTypeEnum.TWID);
        }
    }
}
