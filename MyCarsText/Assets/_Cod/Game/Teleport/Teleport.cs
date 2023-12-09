using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform pos;

    void OnTriggerStay(Collider other)
    {
        other.transform.position = pos.transform.position;
    }
}
