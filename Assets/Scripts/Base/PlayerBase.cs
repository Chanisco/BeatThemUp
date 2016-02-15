using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arena;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] public List<FoundObject> Intuition = new List<FoundObject>();
    [SerializeField] public float lifePoints = 100;
    [SerializeField] public PlayerCommands playerCommands;

    enum PositionAgainstPlayer
    {
        LeftOpponent,
        RightOpponent
    }

    private float speed = 0.1f;

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
        if (Input.GetKey(playerCommands.left))
        {
            transform.Translate(-1 * speed,0,0);
            if(opponent == null)
            {
                transform.localScale = new Vector2(-0.5f, 1);
            }
        }
        else if (Input.GetKey(playerCommands.right))
        {
            transform.Translate(1 * speed, 0, 0);
            if (opponent == null)
            {
                transform.localScale = new Vector2(0.5f, 1);
            }
        }

        if (Input.GetKeyDown(playerCommands.up))
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Damage")
        {
            lifePoints = lifePoints - col.gameObject.GetComponent<Hitbox>().damage;
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
            ownRigidbody.velocity = new Vector3(0, 5, 0);
        }
    }

    public string attack()
    {
        if (Input.GetKeyDown(playerCommands.attack))
        {
            return "Light";
        }
        else
        {
            return "Idle";
        }
    }
    

}
