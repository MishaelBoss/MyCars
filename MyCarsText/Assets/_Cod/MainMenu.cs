using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public InputField InputFieldNameRoom;

    public GameObject ErroorPanel;

    public void CreateRoom()
    {
        if (InputFieldNameRoom.text.Length > 3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(InputFieldNameRoom.text, roomOptions);
        }else ErroorPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        if (InputFieldNameRoom.text.Length > 3) PhotonNetwork.JoinRoom(InputFieldNameRoom.text);
        else ErroorPanel.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
