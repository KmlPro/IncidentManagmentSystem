using System;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class TypedIdValue : IEquatable<TypedIdValue>
    {
        public Guid Value { get; }

        protected TypedIdValue()
        {

        }

        protected TypedIdValue(Guid value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is TypedIdValue other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public bool Equals(TypedIdValue other)
        {
            if (other != null)
            {
                return this.Value == other.Value;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(TypedIdValue obj1, TypedIdValue obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }
        public static bool operator !=(TypedIdValue x, TypedIdValue y) => !(x == y);
    }
}
