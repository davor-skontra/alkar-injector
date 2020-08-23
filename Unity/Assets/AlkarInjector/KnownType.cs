using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AlkarInjector.Attributes;
using UnityEngine;

namespace AlkarInjector
{
    public class KnownType
    {
        private readonly List<FieldInfo> _ownComponentFields = new List<FieldInfo>();
        private readonly List<FieldInfo> _parentComponentFields = new List<FieldInfo>();
        private readonly List<FieldInfo> _childComponentFields = new List<FieldInfo>();

        public KnownType(Type type)
        {
            var fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic
                                    | BindingFlags.Static | BindingFlags.Instance
            );

            foreach (var field in fields)
            {
                var attributes = field
                    .GetCustomAttributes()
                    .ToArray();

                if (HasAttribute<FromOwnComponentAttribute>(attributes))
                {
                    _ownComponentFields.Add(field);
                }

                if (HasAttribute<FromParentComponentAttribute>(attributes))
                {
                    _parentComponentFields.Add(field);
                }

                if (HasAttribute<FromChildComponentAttribute>(attributes))
                {
                    _childComponentFields.Add(field);
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

        public void Resolve<TMonoBehaviour>(TMonoBehaviour monoBehaviour) where TMonoBehaviour : MonoBehaviour
        {
            foreach (var field in _ownComponentFields)
            {
                field.SetValue(monoBehaviour, monoBehaviour.GetComponent(field.FieldType));
            }

            foreach (var field in _parentComponentFields)
            {
                field.SetValue(monoBehaviour, monoBehaviour.GetComponentInParent(field.FieldType));
            }

            foreach (var field in _childComponentFields)
            {
                field.SetValue(monoBehaviour, monoBehaviour.GetComponentInChildren(field.FieldType));
            }
        }
    }
}