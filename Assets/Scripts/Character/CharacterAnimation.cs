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

    public void TurnAnimationOn(string targetbool)
    {
        ConditionsOff();
        animator.SetBool(targetbool, true);

    }
    public void TurnAnimationOff(string targetbool)
    {
        animator.SetBool(targetbool, false);

    }

    public void PlayAnimation(string targetAnimation)
    {
        animator.Play(targetAnimation);
    }
    private void ConditionsOff()
    {
        TurnAnimationOff("Movement");
    }
}
public enum CharacterAnimations
{
    Idle,
    Walk,
    Punch,
    Kick,
    Hit,
    Death
}