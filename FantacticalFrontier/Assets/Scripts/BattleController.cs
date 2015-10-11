using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

    public BattleGrid player;
    public BattleGrid enemy;

    public bool playerTurn = true;

    private bool selectedIsPlayer;
    private Hero selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ClickedCharacter (bool isPlayer, Hero character, int position) {
        if (selected == null && character != null) {
            selected = character;
            selectedIsPlayer = isPlayer;
        } else {
            if (playerTurn) {
                if (selectedIsPlayer) {
                    if (isPlayer) {
                        player.MoveCharacter(selected, position, true);
                        selected = null;
                        selectedIsPlayer = false;
                    } else {
                        selected = character;
                        selectedIsPlayer = false;
                    }
                } 
            }
        }
    }

    void NextTurn () {
        playerTurn = !playerTurn;
        if (playerTurn) {
            player.ResetCharacterTurns();
        }
    }
}
