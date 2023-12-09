using UnityEngine;

public class ClosePanelAnim : MonoBehaviour
{
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
            Invoke("FalsePhone", 1f);
            anim.SetTrigger("Black");
            Invoke("FalsePhone", 2f);

        }
    }

    private void FalsePhone()
    {
        Phone.SetActive(false);
    }
}
