using Project.Game.Player;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Controller p))
            gameObject.SetActive(false);
    }
}
