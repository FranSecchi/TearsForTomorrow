using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;
    public Animator _anim;
    private NavMeshAgent agent;
    private Transform item;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoveAnimation();
    }

    private void CheckMoveAnimation()
    {
        _anim.SetFloat("Speed", agent.velocity.magnitude);
        
    }
    public void TakeItem(Transform item)
    {
        _anim.SetTrigger("GrabItem");
        this.item = item;
        StartCoroutine(SetItemInHand());
    }
    IEnumerator SetItemInHand()
    {
        if (item == null)
            yield break;
        yield return new WaitForSeconds(1f);
        item.gameObject.SetActive(true);
    }
    public void Interact()
    {
        _anim.SetTrigger("Interact");
    }
    public void Talk(bool talking)
    {
        _anim.SetBool("Talking", talking);
    }
}
