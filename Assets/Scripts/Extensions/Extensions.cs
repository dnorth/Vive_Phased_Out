using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class Extensions
    {
        public static GameObject FindInChildren(this GameObject go, string name)
        {
            return (from x in go.GetComponentsInChildren<Transform>()
                    where x.gameObject.name == name
                    select x.gameObject).First();
        }

        public static T FindInChildren<T>(this GameObject go)
        {
            return (from x in go.GetComponentsInChildren<T>()
                    select x).First();
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            var component = go.GetComponent<T>();
            return component == null ? go.AddComponent<T>() : component;
        }
    }
}
