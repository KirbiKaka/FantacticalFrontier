using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleGrid : MonoBehaviour {

    public BattleController battleController;
    public bool isPlayer;

    /**      _0_|_1_|_2_ x
     *    0 | 0   3   6
     *    1 | 1   4   7
     *    2 | 2   5   8
     *    y FRONT    BACK
     * */
    Hero[] characters = new Hero[9];
    SpriteRenderer[] sprites = new SpriteRenderer[9];

	// Use this for initialization
    void Start () {

        for (int i = 0; i < 9; i++) {
            sprites[i] = transform.Find("Sprite " + i).GetComponent<SpriteRenderer>();
        }

        if (isPlayer) {
            for (int i = 0; i < PlayerArmy.GetActiveHeroes().Count; i++) {
                characters[i] = PlayerArmy.GetActiveHeroes()[i];
            }

            SetSprites();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
            for (int i = 0; i < sprites.Length; i++) {
                foreach (RaycastHit2D hit in hits) {
                    if (sprites[i].GetComponent<BoxCollider2D>() == hit.collider) {
                        battleController.ClickedCharacter(isPlayer, characters[i], i);
                    }
                }
            }
        }
	    
	}

    /** Moves the character to the new position.
     *  If another character is there, swap positions.
     *  Returns true if the characters successfully moves. */
    public bool MoveCharacter (Hero mover, int newPos, bool useMoves) {
        int origPos = GetPosition(mover);
        if (origPos == -1) {
            Debug.LogError("Trying to move character who is not on battlefield.");
            return false;
        }
        if (characters[newPos] == null) {
            if (mover.movesLeft <= 0) {
                return false;
            }
            characters[origPos] = null;
            characters[newPos] = mover;
            mover.movesLeft--;
        } else {
            if (mover.movesLeft <= 0 || characters[newPos].movesLeft <= 0) {
                return false;
            }
            characters[origPos] = characters[newPos];
            characters[newPos] = mover;
            characters[origPos].movesLeft--;
            mover.movesLeft--;
        }
        SetSprites();
        return true;
    }

    public int GetPosition (Hero h) {
        for (int i = 0; i < characters.Length; i++) {
            if (characters[i] == h) {
                return i;
            }
        }
        return -1;
    }

    /** Sets the sprites to match the characters.
     *  Call this any time the grid changes. */
    private void SetSprites () {
        for (int i = 0; i < characters.Length; i++) {
            sprites[i].sprite = null;
            if (characters[i] != null) {
                sprites[i].sprite = characters[i].GetCurrentSprite();
            }
        }
    }

    public void ResetCharacterTurns () {
        for (int i = 0; i < characters.Length; i++) {
            if (characters[i] != null) {
                characters[i].movesLeft = 1;
            }
        }
    }

    public int GridTo1D (int x, int y) {
        return x * 3 + y;
    }

    public int GridTo2D_x (int p) {
        return p / 3;
    }

    public int GridTo2D_y (int p) {
        return p % 3;
    }

}
