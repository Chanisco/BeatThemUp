using UnityEngine;
using System.Collections;
using Controlls;

namespace Controlls
{
    public class PlayerControllBase : MonoBehaviour
    {
        playerCommands Player1Settings()
        {
            return playerCommands();
        }

        playerCommands Player2Settings()
        {
            return playerCommands();
        }
    }

    public class playerCommands
    {
        public KeyCode left;
        public KeyCode right;
        public KeyCode up;

        public KeyCode attack;

        public playerCommands(KeyCode Left, KeyCode Right, KeyCode Up, KeyCode Attack)
        {
            this.left = Left;
            this.right = Right;
            this.up = Up;

            this.attack = Attack;
        }

    }
}