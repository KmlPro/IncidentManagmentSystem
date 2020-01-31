using System;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public Guid Value { get; }

        protected TypedIdValueBase()
        {

        }

        protected TypedIdValueBase(Guid value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is TypedIdValueBase other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public bool Equals(TypedIdValueBase other)
        {
            return this.Value == other.Value;
        }

        public static bool operator ==(TypedIdValueBase obj1, TypedIdValueBase obj2)
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
        public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y) => !(x == y);
    }
}
