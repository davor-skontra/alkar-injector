using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alkar.Attributes;
using AlkarSource.Attributes;

namespace Alkar
{
    public class KnownType
    {


        public KnownType(Type type)
        {
            var fields = type.GetFields();

            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes().ToArray();

                if (HasAttribute<FromOwnComponentAttribute>(attributes))
                {
                    OwnComponentFields.Add(field);
                }

                if (HasAttribute<FromParentComponentAttribute>(attributes))
                {
                    ParentComponentFields.Add(field);
                }

                if (HasAttribute<FromChildComponentAttribute>(attributes))
                {
                    ChildComponentFields.Add(field);
                }
            }

            bool HasAttribute<TAttribute>(Attribute[] attributes) where TAttribute : Attribute
            {
                foreach (var ownedAttribute in attributes)
                {
                    if (ownedAttribute is TAttribute)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        
        public List<FieldInfo> OwnComponentFields { get; } = new List<FieldInfo>();
        public List<FieldInfo> ParentComponentFields { get; } = new List<FieldInfo>();
        public List<FieldInfo> ChildComponentFields { get; } = new List<FieldInfo>();
    }
}