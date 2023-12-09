using UnityEngine;

public class SMS : MonoBehaviour
{
    public GameObject panel;
    public GameObject Cub;

    void OnTriggerStay(Collider other)
    {
        panel.SetActive(true);
        Cub.SetActive(false);
    }

}
