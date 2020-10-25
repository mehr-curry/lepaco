using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public IEnumerable<ITokenizer> Tokenizers { get; }

        public Lexer(TextReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            Tokenizers = new ITokenizer[]
            {
                new StringTokenizer(_reader), 
                new CompareOperatorTokenizer(_reader), 
                new IdentifierTokenizer(_reader)
            };
        }

        public async ValueTask<Token> NextTokenAsync()
        {
            foreach (var tokenizer in Tokenizers)
            {
                
            }

            return new Token(string.Empty);
        }

        public unsafe Token GetNextToken()
        {
            var buffer = new char[50];
            fixed (char* b = &buffer[0])
            {
                ////var type = TokenType.None;
                ////var explicitIdentifierUsed = false;
                //var i = 0;
                //for (var next = _reader.Read(); i <= buffer.Length && -1 != next; i++, next = _reader.Read())
                //{
                //    if (i == buffer.Length) throw new OutOfMemoryException($"{nameof(buffer)} was to small.");

                //    // RegEx-Beispiel für Identifier
                //    // \[*[A-Za-z_]+[A-Za-z0-9_]*\]*

                //    var character = (char)next;
                //    var isAlpha = character >= 'a' && character <= 'z' ||
                //                  character >= 'A' && character <= 'Z';
                //    var isNumeric = character >= '0' && character <= '9';
                //    //var isExplicitIdentifierStartChar = character == '[';
                //    var isIdentifierStartChar = isAlpha /*|| isExplicitIdentifierStartChar*/;
                //    // var isNumeric
                //    var isIdentifierFollowupChar = isAlpha || isNumeric;
                //    // var isOperator

                //    if (!isIdentifierStartChar && i == 0)
                //    {
                //        throw new IdentifierCannotStartWithDigitException();
                //    }

                //    if (isIdentifierStartChar || isIdentifierFollowupChar)
                //    {
                //        buffer[i] = character;
                //    }
                //}

                //return new Token(new string(b, 0, i), TODO);

                return new Token(string.Empty);
            }
        }

        public class IdentifierCannotStartWithDigitException : Exception
        {
        }
    }


    //public enum TokenType
    //{
    //    None,
    //    Identifier,
    //    Operator,
    //    Value,
    //}

    public readonly struct Token
    {
        public Token(string name)
        {
            Name = name;
        }
        public string Name { get; }
        
    }

}
