using ExpectedObjects;
using MaskHelper.Services;

namespace MaskHelperUnitTest
{
    public class MaskHelperUnitTest
    {
        private readonly IGetStrService _strService;

        public MaskHelperUnitTest()
        {
            _strService= new GetStrService();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_AddrMask()
        {
            string str = "test";
            var actual = _strService.GetAddrMask(str).ToExpectedObject();
            string ans = "test****";
            actual.ShouldEqual(ans);
        }
    }
}