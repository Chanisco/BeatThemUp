using UnityEngine;
using System.Collections;

public class Mila : PlayerBase {

    [SerializeField] private GameObject LightAttackObject;


    void Update()
    {
        if(attack() == "Light")
        {
            LightAttackObject.SetActive(true);
            
        }
        BasicMovement();
    }
}
