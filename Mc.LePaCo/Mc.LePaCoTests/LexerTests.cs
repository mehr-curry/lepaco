using Xunit;
using Mc.LePaCo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Mc.LePaCo.Tests
{
    public class LexerTests
    {
        [Fact()]
        public void TokenizeTest()
        {
            var condition = "property = 'abc'";
            var lexer = new Lexer(new StringReader(condition));

            Assert.NotNull(lexer);

            var token = lexer.GetNextToken();

            Assert.Equal("property", token.Name);
        }
    }
}