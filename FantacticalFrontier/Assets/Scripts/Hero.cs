using UnityEngine;
using System.Collections;

public class Hero {

    public string name;
    public PlayerArmy.HeroType type;
    public int level;

    public int hpMax;
    private int hpCurr;

    // Use this for initialization
    void Start () {

    }

    public void Initialize (string name, PlayerArmy.HeroType type) {
        this.name = name;
        this.type = type;
        hpMax = 10;
        hpCurr = hpMax;
    }

    // Update is called once per frame
    void Update () {

    }
}
