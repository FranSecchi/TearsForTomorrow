using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        StartCoroutine(LoadAsync(scene));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsync(string scene)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);

        while (!op.isDone)
        {
            Debug.Log(Mathf.Clamp01(op.progress / 09));
            yield return null;
        }
    }
}
