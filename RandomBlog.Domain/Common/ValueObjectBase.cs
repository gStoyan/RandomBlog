namespace RandomBlog.Domain.Common
{
    public interface IValueObject
    {
    }
    public abstract class ValueObjectBase : IValueObject
    {
        protected static bool EqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left?.Equals(right!) != false;
        }

        protected static bool NotEqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObjectBase)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }


        protected abstract IEnumerable<object> GetEqualityComponents();

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
