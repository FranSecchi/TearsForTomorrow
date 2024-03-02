using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ElevatorPlants : MonoBehaviour, Interactuable
{
    public bool first_time = true;
    public bool open = false;
    public GameObject current;
    public GameObject Panel;
    public GameObject codeInputPanel;
    public Animator anim;
    public Transform StandPoint;
    public List<GameObject> Maps;
    public TMP_InputField codeInputField;
    private void Start()
    {
        Panel.SetActive(false);
        codeInputPanel.SetActive(false);
    }
    public void LoadScene(int epoca)
    {
        //if (SceneManager.GetActiveScene().name == scene)
        //    return;
        //StartCoroutine(LoadAsync(scene));
        if (current.name.Equals(Maps[epoca].name))
            return;
        ShaderModifier.changeShader((Times)epoca);
        StartCoroutine(ChangeMap(Maps[epoca]));
        
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

    public void Interact(bool activate)
    {
        if(first_time){
            LoadScene(1);
            anim.SetTrigger("Open");
            first_time = false;
        }
        else{codeInputPanel.SetActive(!codeInputPanel.activeSelf);}
    }
    public void CheckCode()
    {
        // Check player Input, Call from a button
        // if code correct:  Panel.SetActive(true); codeInputPanel.SetActive(false);
        string enteredCode = codeInputField.text;
        if (enteredCode.Equals("1234"))
        {
            Panel.SetActive(true);
            codeInputPanel.SetActive(false);
        }
    }
    public Transform getStandPosition()
    {
        return StandPoint;
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
}
