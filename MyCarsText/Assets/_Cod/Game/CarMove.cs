using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.Demo.SlotRacer;

public class CarMove : MonoBehaviour
{
    public PhotonView view;

    public GameObject Camerar;

    public PlayerController scriptPlayerController;

    [SerializeField] private int coins;
    [SerializeField] private Text coinsText;

    [Header("before headlight")]
    public GameObject _before;

    [Header("ass headlight")]
    public GameObject _accBefore;

    [Header("squeaking sound")]
    public AudioSource _squeaking;

    private void Awake()
    {
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            Camerar.SetActive(false);
            scriptPlayerController.enabled = false;
        }
    }

    private void Start()
    {
        _squeaking = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            _before.SetActive(!_before.activeSelf);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
        {
            _accBefore.SetActive(!_accBefore.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            _squeaking.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
    }
}