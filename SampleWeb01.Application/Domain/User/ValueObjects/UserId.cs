namespace SampleWeb01.Application.Domain.User.ValueObjects
{
    public class UserId: IEquatable<UserId>
    {
        private readonly string value;
        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length <= 5) throw new ArgumentException("ユーザーIDは5文字以内です。");

            this.value = value;
        }

        public bool Equals(UserId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(this.value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false; 
            if (ReferenceEquals(this, obj)) return true; 
            if (obj.GetType() != this.GetType()) return false; 
            return Equals((UserId)obj);
        }
    }
}
