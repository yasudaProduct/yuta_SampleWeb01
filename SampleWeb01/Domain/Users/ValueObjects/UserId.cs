namespace SampleWeb01.Domain.ValueObjects
{
    internal class UserId: IEquatable<UserId>
    {
        private readonly string value;
        public UserId()
        {
            this.value = Guid.NewGuid().ToString();
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

        //public override int GetHashCode()
        //{
        //    unchecked
        //    {
        //        //return ((UserId != null ? UserId.GetHashCode() : 0) * 397);
        //    }
            
        //}
    }
}
