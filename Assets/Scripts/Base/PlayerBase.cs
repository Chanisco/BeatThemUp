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
    private KeyCode Jump = KeyCode.W;
    [SerializeField]
    private KeyCode Left = KeyCode.A;
    [SerializeField]
    private KeyCode Right = KeyCode.D;
    [SerializeField]
    private KeyCode Down = KeyCode.S;

    private float speed = 0.1f;

    [SerializeField]
    private KeyCode LightAttack = KeyCode.F;

    private bool OnPlatform = false;
    [SerializeField]
    private Rigidbody2D ownRigidbody;

    void Awake()
    {
        Init();
    }

    void Update()
    {

    }

    public virtual void Init()
    {
       // ownRigidbody = GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D col)
    {
       // Debug.Log("Showme = " + col.transform.gameObject.name);
        if (col.transform.tag == "LightAtk")
        {
            //TODO Delayfrom movement
        }

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
