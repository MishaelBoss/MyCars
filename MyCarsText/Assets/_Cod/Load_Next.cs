using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Next : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public int SceneID;

    private void Start()
    {
        StartCoroutine(LoadSceneCor());
    }
    IEnumerator LoadSceneCor()
    {
        if(Input.GetKey(KeyCode.Escape))
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
    }
}
