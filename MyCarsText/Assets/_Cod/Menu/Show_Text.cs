using UnityEngine;

public class Show_Text : MonoBehaviour
{
    [SerializeField] GameObject HeartText;

    private void Start()
    {
        HeartText.SetActive(false);
    }

    public void OnMouseOver()
    {
        HeartText.SetActive(true);
    }

    public void OnMouseExit()
    {
        HeartText.SetActive(false);
    }
}
