using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Arena
{
    public class ArenaManagement : MonoBehaviour
    {
        [SerializeField]
        public int AmountOfPlayers;
        public List<PlayerData> Players = new List<PlayerData>();

        [SerializeField]
        public Vector2 Player1Pos, Player2Pos;
        
        public void InsertPlayer(CharacterEnum character)
        {
            Players.Add(new PlayerData(Players.Count,character,true));
        }

        public void InsertNPC(CharacterEnum character)
        {
            Players.Add(new PlayerData(Players.Count, character,false));
        }


        public void StartTheFight()
        {

        }

        void Update()
        {
            
        }

    }

    public class PlayerData
    {

        int playerNumber;
        CharacterEnum targetCharacter;
        bool Controllable;

        public PlayerData(int PlayerNumber,CharacterEnum targetChar,bool isControllable)
        {
            this.playerNumber = PlayerNumber;
            this.targetCharacter = targetChar;
        }

    }
}
