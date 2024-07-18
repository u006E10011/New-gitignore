using System.Collections.Generic;
using UnityEngine;

namespace Project.Shop
{
    [CreateAssetMenu(fileName = "Product", menuName = "ScriptableObject/Product")]
    public class Product : ScriptableObject
    {
        public Sprite Icon;

        public string Name => name;
        public int CurrentLevel;

        public List<Upgrade> Upgrades;

    }
}