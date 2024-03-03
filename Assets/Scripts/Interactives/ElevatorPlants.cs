using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ElevatorPlants : MonoBehaviour, Interactuable
{
    public static bool first_time = true;
    public GameObject current;
    public GameObject Panel;
    public GameObject codeInputPanel;
    public Transform StandPoint;
    public List<GameObject> Maps;
    public TMP_InputField codeInputField;
    public GameObject doors;
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
        LevelMusicManager.setTime((Times)epoca);
        ChangeMap(Maps[epoca]);
        
    }
    void ChangeMap(GameObject map)
    {
        map.SetActive(true);
        current.SetActive(false);
        current = map;
    }
    public IEnumerator openDoors(){
        doors.GetComponent<ElevatorDoors>().Interact(true);
        yield return new WaitForSeconds(4f);
        doors.GetComponent<ElevatorDoors>().Interact(false);
    }
    public IEnumerator closeDoors(){
        doors.GetComponent<ElevatorDoors>().Interact(false);
        yield return new WaitForSeconds(4f);
        doors.GetComponent<ElevatorDoors>().Interact(false);
    }

    public void Interact(bool activate)
    {
        if(first_time){
            LoadScene(1);
            StartCoroutine(openDoors());
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
