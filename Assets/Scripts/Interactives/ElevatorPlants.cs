using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorPlants : MonoBehaviour, Interactuable
{
    public GameObject current;
    public GameObject Panel;
    public Animator anim;
    public Transform StandPoint;
    public List<GameObject> Maps;
    private void Start()
    {
        Panel.SetActive(false);
    }
    public void LoadScene(string scene)
    {
        //if (SceneManager.GetActiveScene().name == scene)
        //    return;
        //StartCoroutine(LoadAsync(scene));
        if (current.name.Equals(scene))
            return;
        foreach(GameObject map in Maps)
        {
            if (map.name.Equals(scene))
            {
                StartCoroutine(ChangeMap(map));
            }
        }
    }
    IEnumerator ChangeMap(GameObject map)
    {
        anim.SetTrigger("Close");
        yield return new WaitForSeconds(4f);
        anim.SetTrigger("Open");

        map.SetActive(true);
        current.SetActive(false);
        current = map;
    }
    //IEnumerator LoadAsync(string scene)
    //{
    //    AsyncOperation op = SceneManager.LoadSceneAsync(scene);
    //    op.allowSceneActivation = false;
    //    anim.SetTrigger("Close");
    //    while (!op.isDone)
    //    {
    //        Debug.Log(Mathf.Clamp01(op.progress / 09));
    //        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
    //        if (stateInfo.IsName("Close") && stateInfo.normalizedTime >= 1.0f)
    //        {
    //            // Animation has finished, allow scene activation
    //            op.allowSceneActivation = true;
    //        }
    //        yield return null;
    //    }
    //}

    public void Interact(bool activate)
    {
        Panel.SetActive(!Panel.activeSelf);
    }

    public Transform getStandPosition()
    {
        return StandPoint;
    }
}
