using System;
using System.IO;

namespace Mc.LePaCo
{
    public class IdentifierTokenizer : ITokenizer
    {
        public TextReader Reader { get; }

        public IdentifierTokenizer(TextReader reader)
        {
            Reader = reader;
        }

        public bool Maybe()
        {
            var next = Reader.Peek();
            return next == '[' || char.IsLetter((char)next);
        }

        public (Token Token, Range CharactersTaken) Get(Span<char> stream, int start)
        {
            throw new NotImplementedException();
        }

        public Token Get(ref Span<char> stream)
        {
            throw new NotImplementedException();
        }
    }
}