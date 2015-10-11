using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleGrid : MonoBehaviour {

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

        for (int i = 0; i < PlayerArmy.GetActiveHeroes().Count; i++) {
            characters[i] = PlayerArmy.GetActiveHeroes()[i];
        }

        SetSprites();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SetSprites () {
        for (int i = 0; i < characters.Length; i++) {
            sprites[i].sprite = null;
            if (characters[i] != null) {
                sprites[i].sprite = characters[i].GetCurrentSprite();
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
