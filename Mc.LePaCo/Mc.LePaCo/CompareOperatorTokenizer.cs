using System;
using System.IO;

namespace Mc.LePaCo
{
    public class CompareOperatorTokenizer : ITokenizer
    {
        public TextReader Reader { get; }

        public CompareOperatorTokenizer(TextReader reader)
        {
            Reader = reader;
        }

        public bool Maybe()
        {
            var next = Reader.Peek();
            return next == '=' || next == '!' || next == '>' || next == '<';
        }

        public Token Get(Span<char> stream, int start)
        {
            throw new NotImplementedException();
        }
    }
}