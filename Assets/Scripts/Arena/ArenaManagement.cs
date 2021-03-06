﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Controlls;
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
		[SerializeField] private bool gameRunning=true;

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
            Application.targetFrameRate = 60;
            if (gameRunning) {
				CheckOnHealth ();
			}
        }

        void CheckOnHealth()
        {
            healthBar.ChangeHealth(0, Players[0].playerInformation.lifePoints);
            healthBar.ChangeHealth(1, Players[1].playerInformation.lifePoints);
			if (Players [0].playerInformation.lifePoints <= 0 || Players [1].playerInformation.lifePoints<=0) {
				Players [0].playerInformation.gameRunning = false;
				Players [1].playerInformation.gameRunning = false;
				gameRunning = false;
			}
        }

        void InstantiatePlayer()
        {
			//foreach(Gameobject char in chosenCharacters){
            for (int i = 0;i < chosenCharacters.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        GameObject Player1 = Instantiate(chosenCharacters[i], new Vector3(-5, -4, 0.05f), Quaternion.identity) as GameObject;
                        Player1.name = chosenCharacters[i].name + i;
                        Player1.transform.parent = transform;
                        PlayerBase Player1Base = Player1.GetComponent<PlayerBase>();
                        Player1Base.playerCommands = PlayerControllBase.Player1Settings();
                        Players.Add(new PlayerData(i, CharacterEnum.Mila, true, Player1Base));

                    break;
				case 1:
						GameObject Player2 = Instantiate (chosenCharacters [i], new Vector3 (5, -4, 0), Quaternion.identity) as GameObject;
						Player2.name = chosenCharacters [i].name + i;
						Player2.transform.parent = transform;
						Player2.transform.localScale = new Vector3 (-Player2.transform.localScale.x, Player2.transform.localScale.y, Player2.transform.localScale.z);
                        PlayerBase Player2Base = Player2.GetComponent<PlayerBase>();
                        Player2Base.playerCommands = PlayerControllBase.Player2Settings();
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
