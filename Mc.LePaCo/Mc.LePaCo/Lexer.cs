using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace Mc.LePaCo
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>(Object.Property='123' or Object.Property.Property=1) and "1"&lt;&gt;"2"</example></example>
    public class Lexer
    {
        private readonly TextReader _reader;

        public static IReadOnlyCollection<string> AvailableTokens = new ReadOnlyCollection<string>(
            new List<string>
            {
                // logische Operatoren
                "and", "or", "xor",
                // Gruppierungsoperatoren
                "(", ")",
                // Vergleichsoperatoren
                "=", "<>", "<", ">",
                // Dereferenzierung
                ".",
                // Auswahl
                "in", ",",
                // Identifier
                "[", "]",
                // Stringliterale
                "\"", "'"
            }
        );

        public Lexer(TextReader reader)
        {
            _reader = reader;
        }

        public unsafe Token GetNextToken()
        {
            var buffer = new char[50];
            fixed (char* b = &buffer[0])
            {

                var type = TokenType.None;

                for (int next = _reader.Read(), i = 0; i <= buffer.Length && -1 != next; i++, next = _reader.Read())
                {
                    if (i == buffer.Length) throw new OutOfMemoryException($"{nameof(buffer)} was to small.");

                    var character = (char)next;
                    var isIdentifier = character >= 'a' && character <= 'z' || character >= 'A' && character <= 'Z';
                    var isIdentifierStart = character == '[';
                    var isIdentifierEnd = character == ']';

                    if (isIdentifierStart)
                    {
                        continue;
                    }

                    if (isIdentifier)
                    {
                        buffer[i] = character;
                        continue;
                    }

                    return new Token(new string(b, 0, i));


                }
            }

            return null;
        }
    }

    public enum TokenType
    {
        None,
        Identifier,
        Operator,
        Value,
    }

    public class Token
    {
        public Token(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }

}
