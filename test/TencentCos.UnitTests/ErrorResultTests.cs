using AspNetCore.TencentCos;
using AspNetCore.TencentCos.Models;
using System;
using System.IO;
using System.Xml.Serialization;
using Xunit;

namespace TencentCos.UnitTests
{
    public class ErrorResultTests
    {
        [Fact]
        public void ShouldDeserializable()
        {
            var path = "Data/Error.xml";
            using (TextReader reader = new StreamReader(path))
            {
                var serializer = new XmlSerializer(typeof(ErrorResult));
                var result = (ErrorResult)serializer.Deserialize(reader);

                Assert.NotNull(result);
                Assert.True(result.Code == "AccessDenied");
                Assert.True(result.Resource == "dorr-1243608725.cos.ap-guangzhou.myqcloud.com/test/Ӫҵִ�ո�����ӡ������-��.jpg");
                Assert.True(result.RequestId == "NWJiNWUwOGZfY2JhMzNiMGFfYTdkZF80NTI1MWE=");
            }

        }
    }
}
