using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject panel;
    public GameObject Phone;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Phone.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }
}
