using Xunit;
using Mc.LePaCo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Mc.LePaCo.Tests
{
    public class LexerTests
    {
        [Fact]
        public void SpanTest()
        {
            var condition = "property='1'";
            var indexOfOperator = condition.IndexOf('=');

            var sw = Stopwatch.StartNew();

            Span<char> span = condition.ToCharArray();
            var leftOperandSpan = span.Slice(0, indexOfOperator).ToString();
            var rightOperandSpan = span.Slice(indexOfOperator + 1).ToString();

            sw.Stop();
            var duration1 = (double)sw.ElapsedTicks / Stopwatch.Frequency;

            sw.Restart();

            var operands = condition.Split('=');
            var leftOperandString = operands[0];
            var rightOperandString = operands[1];

            sw.Stop();
            var duration2 = (double)sw.ElapsedTicks / Stopwatch.Frequency;
        }

        [Fact()]
        public void ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Lexer(null));
        }

        [Fact()]
        public void ShouldGetPropertyTokenAlphanum()
        {
            var condition = "pr0p3rty";
            var lexer = new Lexer(new StringReader(condition));
            var token = lexer.GetNextToken();

            Assert.Equal(condition, token.Name);

        }

        [Fact()]
        public void ShouldThrowIdentifierCannotStartWithDigit()
        {
            var condition = "1pr0p3rty";

            var lexer = new Lexer(new StringReader(condition));
            Assert.Throws<Lexer.IdentifierCannotStartWithDigitException>(() => lexer.GetNextToken());
        }

        [Fact()]
        public void NextTokenAsyncTest()
        {
            var condition = "[pr0p3rty]";
            var reader = new StringReader(condition);
            var lexer = new Lexer(reader);
            var token = lexer.NextTokenAsync().Result;
        }
        
        [Fact]
        public void TestIsIdentifier()
        {
            var condition = "[pr0p3rty]";
            var testee = new IdentifierTokenizer(new StringReader(condition));
                
            Assert.True(testee.Maybe());
        }

        [Fact]
        public void TestIsString()
        {
            var condition = "\"pr0p3rty\"";
            var testee = new StringTokenizer(new StringReader(condition));

            Assert.True(testee.Maybe());

            condition = "'pr0p3rty'";
            testee = new StringTokenizer(new StringReader(condition));

            Assert.True(testee.Maybe());
            
        }

        [Fact]
        public void TestIsOperator()
        {
            var condition = "=";
            var testee = new CompareOperatorTokenizer(new StringReader(condition));

            Assert.True(testee.Maybe());

            condition = "!=";
            testee = new CompareOperatorTokenizer(new StringReader(condition));

            Assert.True(testee.Maybe());
        }
    }
}