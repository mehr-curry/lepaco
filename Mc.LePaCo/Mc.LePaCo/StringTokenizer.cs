using System;
using System.Data;
using System.IO;
using System.Xml.XPath;

namespace Mc.LePaCo
{
    public class StringTokenizer : ITokenizer
    {
        public TextReader Reader { get; }

        public StringTokenizer(TextReader reader)
        {
            Reader = reader;
        }

        public bool Maybe()
        {
            var next = Reader.Peek();
            return IsQuotingChar(next);
        }

        private static bool IsQuotingChar(int next)
        {
            return next == '\'' || next == '"';
        }

        public Token Get(Span<char> stream, int start)
        {
            char? quote = null;

            for (var i = start; i < stream.Length; i++)
            {
                var next = stream[i];
                if (quote == null)
                {
                    if (!IsQuotingChar(next))
                    {
                        throw new ArgumentOutOfRangeException("missing start quote");
                    }

                    quote = next;
                    continue;
                }

                if (next == quote)
                {
                    var charactersRange = start..(i + start);
                    var valueRange = (charactersRange.Start.Value + 1)..(charactersRange.End.Value - 1);
                    var result = new Token(string.Empty, stream[valueRange]);

                    //if (stream.Length > i)
                    //{
                    //    stream = stream[(i + 1)..];
                    //}

                    return result;
                }
            }

            throw new ArgumentOutOfRangeException("missing end quote");
        }
    }
}