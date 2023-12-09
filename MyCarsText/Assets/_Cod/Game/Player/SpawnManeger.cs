using UnityEngine;
using Photon.Pun;

public class SpawnManeger : MonoBehaviour
{
    public GameObject[] Spawn;

    public GameObject Player;

    private void Awake()
    {
        Vector3 randomPosistion = Spawn[Random.Range(0, Spawn.Length)].transform.position;

        PhotonNetwork.Instantiate(Player.name, randomPosistion, Quaternion.identity);
    }
}
