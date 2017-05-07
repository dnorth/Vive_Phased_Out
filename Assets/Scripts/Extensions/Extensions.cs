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
    }
}
