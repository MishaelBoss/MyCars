using UnityEngine.UI;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ListItem : MonoBehaviour
{
    [SerializeField] Text textName;
    [SerializeField] Text textPlayerCount;

    public void SetInfo(RoomInfo info) {
        textName.text = info.Name;
        textPlayerCount.text = info.PlayerCount + "/" + info.MaxPlayers;
    }

    public void JoinToListRoom()
    {
        PhotonNetwork.JoinRoom(textName.text);
    }
}