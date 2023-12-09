using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject myPlayer;

    public float distance = 8;

    void LateUpdate() 
    {
        transform.position = myPlayer.transform.position + Vector3.up * distance;
    }
}
