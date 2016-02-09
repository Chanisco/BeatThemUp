using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arena;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    public List<FoundObject> Intuition = new List<FoundObject>();

    enum PositionAgainstPlayer
    {
        LeftOpponent,
        RightOpponent
    }

    [SerializeField]
    private KeyCode Jump = KeyCode.W;
    [SerializeField]
    private KeyCode Left = KeyCode.A;
    [SerializeField]
    private KeyCode Right = KeyCode.D;

    private float speed = 0.1f;

    [SerializeField]
    private KeyCode LightAttack = KeyCode.F;

    private bool OnPlatform = false;

    [SerializeField] private Rigidbody2D ownRigidbody;
    [SerializeField] public Transform opponent;

    void Awake()
    {
        Init();
    }
    

    public virtual void Init()
    {

    }

    public void SendInformationToArena()
    {

    }

    public void FindObject(FoundObject target)
    {
        if (Intuition.Count == 0)
        {
            Intuition.Add(target);
        }
        else
        {
            for (int i = 0; i < Intuition.Count; i++)
            {
                if (Intuition[i].objectType == target.objectType)
                {
                    break;
                }

                if (i == Intuition.Count)
                {
                    Intuition.Add(target);
                }
            }
        }
    }

    public void LoseObject(FoundObject target)
    {
        List<int> removingObjects = new List<int>();
        for (int i = 0;i < Intuition.Count;i++)
        {
            if(Intuition[i].objectName == target.objectName)
            {
                Intuition.RemoveAt(i);
            }

        }
    }
    

    //Commands
    public virtual void BasicMovement()
    {
        if (Input.GetKey(Left))
        {
            transform.Translate(-1 * speed,0,0);
            if(opponent == null)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        else if (Input.GetKey(Right))
        {
            transform.Translate(1 * speed, 0, 0);
            if (opponent == null)
            {
                transform.localScale = new Vector2(1, 1);
            }
        }

        if (Input.GetKeyDown(Jump))
        {
            JumpCommand();
        }
    }

    public virtual void LookAtOpponent()
    {
        
        if (opponent != null)
        {
            Vector2 t = this.transform.position;
            Vector2 o = this.opponent.position;
            Debug.Log("Bite me =" + t + " , " + o);
            if (t.x > o.x)
            {
                transform.localScale = new Vector2(-1,1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
        {
            OnPlatform = true;
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Platform")
        {
            OnPlatform = false;
        }
    }

    private void JumpCommand()
    {
        if (OnPlatform)
        {
            ownRigidbody.velocity = new Vector3(0, 7, 0);
        }
    }

    public string attack()
    {
        if (Input.GetKeyDown(LightAttack))
        {
            return "Light";
        }
        else
        {
            return "Wait";
        }
    }

    public void TakeDamage()
    {

    }
    

}
