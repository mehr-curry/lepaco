using Xunit;
using Mc.LePaCo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc.LePaCo.Tests
{
    public class StringTokenizerTests
    {
        [Fact()]
        public void GetTest()
        {
            var data = new Span<char>("\"test\"".ToCharArray());
            var testee = new StringTokenizer(null);
            var result = testee.Get(data, 0);
            Assert.Equal("test", new string(data[..1]));
        }

        [Fact()]
        public void GetThrowTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var data = new Span<char>("\"test".ToCharArray());
                var testee = new StringTokenizer(null);
                testee.Get(data, 0);
            });
        }
    }
}