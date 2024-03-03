using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    public GameObject LoadingPanel;
    public List<GameObject> panels;
    public void LoadScene(string scene)
    {
        StartCoroutine(LoadAsync(scene));
    }

    IEnumerator LoadAsync(string scene)
    {
        foreach(GameObject pan in panels)
        {
            pan.SetActive(false);
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(scene);

        while (!op.isDone)
        {
            Debug.Log(Mathf.Clamp01(op.progress / 09));
            yield return null;
        }

    }
}
