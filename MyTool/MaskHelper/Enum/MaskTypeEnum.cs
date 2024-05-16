using System.ComponentModel;

namespace MaskHelper.Enum
{
    public enum MaskTypeEnum
    {
        [Description("姓名")]
        Name,
        [Description("生日")]
        Birthday,
        [Description("台灣身分證號")]
        TWID,
        [Description("護照號碼")]
        PassportID,
        [Description("連絡電話")]
        Phone,
        [Description("手機號碼")]
        CellPhone,
        [Description("Email")]
        Email,
        [Description("地址")]
        Addr,
        [Description("銀行帳號")]
        BankAccount,
        [Description("信用卡號")]
        CreditCardNum,
        [Description("保單號碼")]
        PolicyNum
    }
}
