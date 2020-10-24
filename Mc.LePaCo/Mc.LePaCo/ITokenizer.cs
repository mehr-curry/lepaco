using System;

namespace Mc.LePaCo
{
    public interface ITokenizer
    {
        bool Maybe();
        Token Get(Span<char> stream, int start);
    }
}