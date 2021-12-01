using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Palette.Base.Domain
{
    public abstract record ValueObject : IEquatable<ValueObject>
    {
        private List<PropertyInfo> _properties { get; set; }
        private List<FieldInfo> _fields { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var prop in GetProperties())
                {
                    var value = prop.GetValue(this, null);
                    hash = HashValue(hash, value);
                }

                foreach (var field in GetFields())
                {
                    var value = field.GetValue(this);
                    hash = HashValue(hash, value);
                }

                return hash;
            }
        }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (this._properties == null)
            {
                this._properties = GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                    .ToList();

                // Not available in Core
                // !Attribute.IsDefined(p, typeof(IgnoreMemberAttribute))).ToList();
            }

            return this._properties;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            if (this._fields == null)
            {
                this._fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                    .ToList();
            }

            return this._fields;
        }

        private int HashValue(int seed, object value)
        {
            var currentHash = value?.GetHashCode() ?? 0;

            return (seed * 23) + currentHash;
        }
    }
}
