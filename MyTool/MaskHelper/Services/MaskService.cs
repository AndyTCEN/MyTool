using MaskHelper.Enum;

namespace MaskHelper.Services
{
    public static class MaskService
    {
        private static IMaskService? _maskService;
        public static string MaskStr(this string str,MaskTypeEnum maskType)
        {
            _maskService = maskType switch
            {
                MaskTypeEnum.Name => new MaskName(str),
                MaskTypeEnum.Birthday => new MaskBirthday(str),
                MaskTypeEnum.TWID => new MaskTWID(str),
                MaskTypeEnum.PassportID => new MaskPassportID(str),
                MaskTypeEnum.Phone => new MaskPhone(str),
                MaskTypeEnum.CellPhone => new MaskCellPhone(str),
                MaskTypeEnum.Email => new MaskEmail(str),
                MaskTypeEnum.Addr => new MaskAddr(str),
                MaskTypeEnum.BankAccount => new MaskBankAccount(str),
                MaskTypeEnum.CreditCardNum => new MaskCreditCardNum(str),
                MaskTypeEnum.PolicyNum => new MaskPolicyNum(str),
                _ => throw new NotImplementedException(),
            };
            return _maskService.Mask();
        }
    }

    internal class MaskBase : IMaskService
    {
        internal string str;

        public MaskBase(string str)
        {
            this.str = str;
        }

        public virtual string Mask()
        {
            throw new NotImplementedException();
        }
    }

    internal class MaskName : MaskBase
    {
        public MaskName(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }
    internal class MaskBirthday : MaskBase
    {
        public MaskBirthday(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskTWID : MaskBase
    {
        public MaskTWID(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskPassportID : MaskBase
    {
        public MaskPassportID(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskPhone : MaskBase
    {
        public MaskPhone(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskCellPhone : MaskBase
    {
        public MaskCellPhone(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskEmail : MaskBase
    {
        public MaskEmail(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskAddr : MaskBase
    {
        public MaskAddr(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return this.str;
        }
    }

    internal class MaskBankAccount : MaskBase
    {
        public MaskBankAccount(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskCreditCardNum : MaskBase
    {
        public MaskCreditCardNum(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }

    internal class MaskPolicyNum : MaskBase
    {
        public MaskPolicyNum(string str) : base(str)
        {
        }
        public override string Mask()
        {
            return base.Mask();
        }
    }
}
