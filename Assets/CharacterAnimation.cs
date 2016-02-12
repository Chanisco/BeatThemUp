using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

    private Animator animator;
	// Use this for initialization
	void Awake ()
    {
        animator = GetComponent<Animator>();
        ConditionsOff();
    }

    void TurnAnimationOn(string targetbool)
    {

        animator.SetBool(targetbool, true);

    }
    void TurnAnimationOff(string targetbool)
    {
        animator.SetBool(targetbool, false);

    }
    void ConditionsOff()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Atk", false);
        animator.SetBool("Walk", false);
    }
}
