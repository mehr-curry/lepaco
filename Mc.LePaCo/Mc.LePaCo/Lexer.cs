using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Mc.LePaCo
{
    /// <summary>
    /// 
    /// </summary>
    /// <example>(Object.Property='123' or Object.Property.Property=1) and "1"&lt;&gt;"2"</example></example>
    public class Lexer
    {
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

        public IEnumerable<string> Tokenize(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                while(reader.read)

            }
        }
    }
}
