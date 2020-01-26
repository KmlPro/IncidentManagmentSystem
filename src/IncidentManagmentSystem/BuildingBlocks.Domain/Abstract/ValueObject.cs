using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BuildingBlocks.Domain.Abstract
{
    public class ValueObject : WithCheckRule, IEquatable<ValueObject>
    {
        private List<PropertyInfo> _properties;
        private List<FieldInfo> _fields;

        public static bool operator ==(ValueObject obj1, ValueObject obj2)
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

        public static bool operator !=(ValueObject obj1, ValueObject obj2) => !(obj1 == obj2);

        public bool Equals(ValueObject obj)
        {
            return this.Equals(obj as object);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.GetProperties().All(p => this.PropertiesAreEqual(obj, p))
                && this.GetFields().All(f => this.FieldsAreEqual(obj, f));
        }

        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return Equals(f.GetValue(this), f.GetValue(obj));
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (this._properties == null)
            {
                this._properties = this.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttribute(typeof(ExcludeFromComparisonPropertyAttribute)) == null)
                    .ToList();
            }

            return this._properties;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            if (this._fields == null)
            {
                this._fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(p => p.GetCustomAttribute(typeof(ExcludeFromComparisonPropertyAttribute)) == null)
                    .ToList();
            }

            return this._fields;
        }

        public override int GetHashCode()
        {
            unchecked   //allow overflow
            {
                var hash = 17;
                foreach (var prop in this.GetProperties())
                {
                    var value = prop.GetValue(this, null);
                    hash = this.HashValue(hash, value);
                }

                foreach (var field in this.GetFields())
                {
                    var value = field.GetValue(this);
                    hash = this.HashValue(hash, value);
                }

                return hash;
            }
        }

        private int HashValue(int seed, object value)
        {
            var currentHash = value != null
                ? value.GetHashCode()
                : 0;

            return (seed * 23) + currentHash;
        }
    }
}
