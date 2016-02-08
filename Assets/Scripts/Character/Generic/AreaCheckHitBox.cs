using UnityEngine;
using System.Collections;

public class AreaCheckHitBox : MonoBehaviour {
    public string Collision;

    void OnTiggerEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Collision = "Player";
        }

    }
}
