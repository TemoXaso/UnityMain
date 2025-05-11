using UnityEngine;

public class Protal : MonoBehaviour
{
    public Transform spawnpoint;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = spawnpoint.position;
    }
}
