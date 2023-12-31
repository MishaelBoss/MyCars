using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [Header("PanelConnectPhoton")]
    public GameObject ToConnectPhoton;

    [Header("Region")]
    [SerializeField] string region;

    [Header("InputCreateNameRoom")]
    public InputField InputFieldNameRoom;

    [Header("ErrorPanel")]
    public GameObject ErroorPanel;

    [Header("PanelJoinRoom")]
    [SerializeField] ListItem itemPrefab;
    [SerializeField] Transform content;
    List<RoomInfo> allRoomsInfo = new List<RoomInfo>();

    [Header("Player")]
    private GameObject player;

    [Header("TextNameRoom")]
    [SerializeField] Text _textRoom;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    } 

    public override void OnConnectedToMaster()
    {
        Debug.Log("Вы подключены к:" + PhotonNetwork.CloudRegion);

        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
            ToConnectPhoton.gameObject.SetActive(false);
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Вы были отключены от сервера!");
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) {
            return;
        }

        if (InputFieldNameRoom.text.Length > 3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 10;
            PhotonNetwork.CreateRoom(InputFieldNameRoom.text, roomOptions, TypedLobby.Default);
        }
        else ErroorPanel.SetActive(true);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Комната была создана" + PhotonNetwork.CurrentRoom.Name);
    }

    /*public override void OnJoinedLobby()
    {
        _textRoom.text = "Имя комнаты: " + InputFieldNameRoom.text;
    }*/

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Не удалось создать комнату");
        ErroorPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        if (InputFieldNameRoom.text.Length > 3) PhotonNetwork.JoinRoom(InputFieldNameRoom.text);
        else ErroorPanel.SetActive(true);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList){
            for (int i = 0; i < allRoomsInfo.Count; i++) {
                if (allRoomsInfo[i].masterClientId == info.masterClientId)
                    return;
            }
            ListItem listItem = Instantiate(itemPrefab, content);
            if (listItem != null) {
                listItem.SetInfo(info);
                allRoomsInfo.Add(info);
            }
        }
    }

    public void JoinRandRoom() {
        PhotonNetwork.JoinRandomRoom();
    }

    public void LiveButtonRoom() { 
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        //PhotonNetwork.Destroy(player.gameObject);
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
