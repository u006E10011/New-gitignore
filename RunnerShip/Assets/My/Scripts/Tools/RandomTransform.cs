using System.Collections.Generic;
using UnityEngine;

namespace Project.Tools
{
    public class RandomTransform
    {
        public static void Rotate(List<GameObject> item)
        {
            var rotate = Random.Range(0, 360);

            foreach (var obj in item)
                obj.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }

        public static void Scale(List<GameObject> item, float maxScale, float minScale)
        {
            var scale = Random.Range(minScale, maxScale);

            foreach (var obj in item)
                obj.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

}