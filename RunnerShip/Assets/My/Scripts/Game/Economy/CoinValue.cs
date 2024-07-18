using UnityEngine;

namespace Project.Game.Economy
{
    [CreateAssetMenu(fileName = "ValueCoin", menuName = "ScriptableObject/ValueCoin")]
    public class CoinValue : ScriptableObject
    {
        public int Gold;
        public int Silver;
        public int Bronze;
    }
}