using SampleWeb01.Application.Domain.User.ValueObjects;

namespace SampleWeb01.Domain.User
{
    internal class User : IEquatable<User>
    {

        public User(string userid, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.userId = new UserId(userid);
            ChangeName(name);
        }

        public UserId userId { get; private set; }
        public string name { get; private set; }

        public void ChangeName(string name)
        {
            if(name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("ユーザー名は3文字以上です。",nameof(name));

            this.name = name;
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(userId, other.userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return (userId != null ? userId.GetHashCode() : 0);
        }
    }
}
