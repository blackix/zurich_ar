
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
