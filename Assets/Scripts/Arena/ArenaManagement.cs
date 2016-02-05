using UnityEngine;
using System.Collections;
namespace Arena
{
    public class ArenaManagement : MonoBehaviour
    {
        [SerializeField]
        public int AmountOfPlayers;

        [SerializeField]
        public Vector2 Player1Pos, Player2Pos;
        
        void Start()
        {

        }

        void Update()
        {
            
        }

    }

    public class PlayerData
    {
        int id;
        int playerNumber;

        public PlayerData()
        {
           // this.id
        }

    }
}
