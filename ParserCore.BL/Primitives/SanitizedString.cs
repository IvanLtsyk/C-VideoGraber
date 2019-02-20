using System.Linq;

namespace parserVideo.Primitives
{
    public struct SanitizedString
    {
        public SanitizedString(string value)
        {
            Value = new string(value.Where(c => !char.IsControl(c) && c < 10000).ToArray()).Trim();
        }

        public string Value { get; }

        public static implicit operator SanitizedString(string value)
        {
            return new SanitizedString(value ?? "");
        }

        public static implicit operator string(SanitizedString str)
        {
            return str.Value ?? "";
        }

        public override string ToString()
        {
            return Value ?? "";
        }

        public override bool Equals(object obj)
        {
            if (obj is SanitizedString ss)
            {
                return Value.Equals(ss.Value);
            }

            return Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (Value ?? "").GetHashCode();
        }
    }
}
