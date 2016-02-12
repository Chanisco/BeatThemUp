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
        public List<GameObject> chosenCharacters = new List<GameObject>();
        [SerializeField]
        Healthbar healthBar;

        [SerializeField]
        public Vector2 Player1Pos, Player2Pos;
        
        public void InsertPlayer(CharacterEnum character, PlayerBase targetplayer)
        {
            Players.Add(new PlayerData(Players.Count,character,true,targetplayer));
        }

        public void InsertNPC(CharacterEnum character,  PlayerBase targetplayer)
        {
            Players.Add(new PlayerData(Players.Count, character,false,targetplayer));
        }


        public void StartTheFight()
        {
            InstantiatePlayer();

        }

        void Start()
        {
            StartTheFight();
            healthBar.Init(2);
        }

        void Update()
        {

            CheckOnHealth();
        }

        void CheckOnHealth()
        {


        }

        void InstantiatePlayer()
        {
            for (int i = 0;i < chosenCharacters.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        GameObject Player1 = Instantiate(chosenCharacters[i], new Vector3(-5, 0, 0), Quaternion.identity) as GameObject;
                        Player1.name = chosenCharacters[i].name;
                        Player1.transform.parent = transform;
                        PlayerBase Player1Base = Player1.GetComponent<PlayerBase>();
                        Players.Add(new PlayerData(i, CharacterEnum.Mila, true, Player1Base));

                    break;
                    case 1:
                        GameObject Player2 = Instantiate(chosenCharacters[i], new Vector3(5, 0, 0), Quaternion.identity) as GameObject;
                        Player2.name = chosenCharacters[i].name;
                        Player2.transform.parent = transform;
                        PlayerBase Player2Base = Player2.GetComponent<PlayerBase>();
                        Players.Add(new PlayerData(i, CharacterEnum.Mila, true, Player2Base));

                    break;

                }

            }
        }

    }
    [System.Serializable]
    public class PlayerData
    {

        public int playerNumber;
        public CharacterEnum targetCharacter;
        public bool Controllable;
        public PlayerBase playerInformation;

        public PlayerData(int PlayerNumber,CharacterEnum targetChar,bool isControllable, PlayerBase PlayerInformation)
        {
            this.playerNumber       = PlayerNumber;
            this.targetCharacter    = targetChar;
            this.Controllable       = isControllable;
            this.playerInformation  = PlayerInformation;
        }

    }
}
