using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero {

    public string name;
    public PlayerArmy.HeroType type;
    public int level;

    List<Sprite> heroSprites = new List<Sprite>();
    Sprite currentSprite;

    public int movesLeft = 1;
    private int hpMax;
    private int hpCurr;

    // Use this for initialization
    void Start () {

    }

    public void Initialize (string name, PlayerArmy.HeroType type) {
        this.name = name;
        this.type = type;
        hpMax = 10;
        hpCurr = hpMax;
        LoadSprites();
    }

    void LoadSprites () {
        switch (type) {
            case PlayerArmy.HeroType.Sentinel:
                heroSprites.Add(Resources.Load<Sprite>("CharacterSprites/Sentinel Icon"));
                currentSprite = heroSprites[0];
                break;
            case PlayerArmy.HeroType.Astronomer:
                heroSprites.Add(Resources.Load<Sprite>("CharacterSprites/Stormbringer Icon"));
                currentSprite = heroSprites[0];
                break;
        }
    }

    public Sprite GetCurrentSprite () {
        return currentSprite;
    }

    // Update is called once per frame
    void Update () {

    }

}
