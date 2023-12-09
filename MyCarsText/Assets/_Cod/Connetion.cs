using UnityEngine.SceneManagement;
using Photon.Pun;

public class Connetion : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("ConectRooms");
    }
}
