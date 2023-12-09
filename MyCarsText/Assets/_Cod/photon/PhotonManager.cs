using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;

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

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("�� ���������� �:" + PhotonNetwork.CloudRegion);

        if (!PhotonNetwork.InLobby) ;
        {
            PhotonNetwork.JoinLobby();
            ToConnectPhoton.gameObject.SetActive(false);
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("�� ���� ��������� �� �������!");
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) {
            return;
        }

        if (InputFieldNameRoom.text.Length > 3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 50;
            PhotonNetwork.CreateRoom(InputFieldNameRoom.text, roomOptions, TypedLobby.Default);
            PhotonNetwork.LoadLevel("Game");
        }
        else ErroorPanel.SetActive(true);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("������� ���� �������" + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("�� ������� ������� �������");
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
            ListItem listItem = Instantiate(itemPrefab, content);
            if (listItem != null)
                listItem.SetInfo(info);
        }
    }
}