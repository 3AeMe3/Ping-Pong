using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAnim : MonoBehaviour
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    public void ShowAnimation()
    {
        anim.Play();
        Debug.Log("se repreduce la animacion");

    }

}
