using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mila : PlayerBase{
    [SerializeField] private GameObject LightAttackObject;
    [SerializeField] private GameObject AreaCheckHitBox;


    void Update()
    {
        if(attack() == "Light")
        {
            LightAttackObject.SetActive(true);

        }

        LookAtOpponent();
        BasicMovement();
    }
    
}
