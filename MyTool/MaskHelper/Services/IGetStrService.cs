namespace MaskHelper.Services
{
    public interface IGetStrService
    {
        string GetNameMask(string name);
        string GetBirthdayMask(string Birthday);
        string GeTWIDMask(string TWID);
        string GetPassportIDMask(string PassportID);
        string GetPhoneMask(string Phone);
        string GetCellPhoneMask(string CellPhone);
        string GetEmailMask(string Email);
        string GetAddrMask(string Addr);
        string GetBankAccountMask(string BankAccount);
        string GetCreditCardNumMask(string CreditCardNum);
        string GetPolicyNumMask(string PolicyNum);
    }
}
