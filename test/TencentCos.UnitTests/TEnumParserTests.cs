using AspNetCore.TencentCos;
using Xunit;

namespace TencentCos.UnitTests
{
    public class TEnumParserTests
    {
        [Theory]
        [InlineData("private", XCosAcl.PrivateReadAndWrite)]
        [InlineData("public-read", XCosAcl.PublicReadPrivateWrite)]
        [InlineData("public-read-write", XCosAcl.PublicReadAndWrite)]
        public void Test_TEnumParser_ShortName(string shortName, XCosAcl expected)
        {
            var parser = new TEnumParser<XCosAcl>();
            Assert.Equal(parser.ParseFromShortName(shortName), expected);
        }

        [Theory]
        [InlineData("˽�ж�д", XCosAcl.PrivateReadAndWrite)]
        [InlineData("���ж�˽��д", XCosAcl.PublicReadPrivateWrite)]
        [InlineData("���ж�д", XCosAcl.PublicReadAndWrite)]
        public void Test_TEnumParser_DisplayName(string displayName, XCosAcl expected)
        {
            var parser = new TEnumParser<XCosAcl>();
            Assert.Equal(parser.ParseFromDisplayName(displayName), expected);
        }
    }
}
