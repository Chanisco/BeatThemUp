using UnityEngine;
using System.Collections;
using Arena;

public class PlayerBase : MonoBehaviour
{
    enum PositionAgainstPlayer
    {
        LeftOpponent,
        RightOpponent
    }

    [SerializeField]
    private KeyCode Jump, Left, Right, Down;
    private float speed = 0.1f;
    [SerializeField]
    private bool OnPlatform = false;

    private Rigidbody ownRigidbody;

    void Awake()
    {
        Init();
    }

    void Update()
    {

    }

    public virtual void Init()
    {
        ownRigidbody = GetComponent<Rigidbody>();
    }

    public void SendInformationToArena()
    {

    }

    //Commands
    public virtual void BasicMovement()
    {
        if (Input.GetKey(Left))
        {
            transform.Translate(-1 * speed,0,0);
        }
        else if (Input.GetKey(Right))
        {
            transform.Translate(1 * speed, 0, 0);
        }

        if (Input.GetKeyDown(Jump))
        {
            JumpCommand();
        }
    }

    private void On2DCollision2DEnter(Collision col)
    {
        if(col.transform.tag == "Platform")
        {
            OnPlatform = true;
        }
    }

    private void OnCollision2DExit(Collision col)
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


}
