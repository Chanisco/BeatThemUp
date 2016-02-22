﻿using UnityEngine;
using System.Collections;
using Controlls;

namespace Controlls
{
    public class PlayerControllBase : MonoBehaviour
    {
        public static PlayerCommands Player1Settings()
        {
            return new PlayerCommands(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.F,KeyCode.G);
        }

        public static PlayerCommands Player2Settings()
        {
            return new PlayerCommands(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.Keypad2, KeyCode.Keypad3);
        }
    }

  
}
[System.Serializable]
public class PlayerCommands
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public KeyCode lightAttack;
    public KeyCode heavyAttack;

    public PlayerCommands(KeyCode Left, KeyCode Right, KeyCode Up, KeyCode LightAttack,KeyCode HeavyAttack)
    {
        this.left = Left;
        this.right = Right;
        this.up = Up;

        this.lightAttack = LightAttack;
        this.heavyAttack = HeavyAttack;
    }

}