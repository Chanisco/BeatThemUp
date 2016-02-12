using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mila : PlayerBase{
    [SerializeField] private GameObject AreaCheckHitBox;
    [SerializeField] private HitboxElement AttackHitbox;


    void Update()
    {
        if(attack() == "Light")
        {
            Hit(0.5f,5,HitPosition.TOP);
        }

        LookAtOpponent();
        BasicMovement();
    }
    
    void Hit(float Lifetime,float Damage,HitPosition HitArea)
    {
        AttackHitbox.hitboxClass.hitArea = HitArea;
        AttackHitbox.hitboxClass.damage = Damage / 2;
        AttackHitbox.hitboxClass.lifetime = Lifetime;
        AttackHitbox.objectGameObject.SetActive(true);
    }
}
