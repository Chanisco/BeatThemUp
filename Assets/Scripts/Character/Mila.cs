using UnityEngine;
using System.Collections;

public class Mila : PlayerBase {
    [SerializeField] private GameObject LightAttackObject;

    [SerializeField] private GameObject AreaCheckHitBox;


    void Update()
    {
        if(attack() == "Light")
        {
            LightAttackObject.SetActive(true);
            
        }
        BasicMovement();
    }
    
}
