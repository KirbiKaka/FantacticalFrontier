using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/** Static class for controlling all the player's data. */
public class PlayerArmy : MonoBehaviour {

    public enum HeroType {
        Sentinel, Huntsman, Jouster,
        Patrol, Sharpshooter, Diviner,
        Bartender, Astronomer, Zealot
    };

    public static readonly int MAX_HEROES = 20;
    public static readonly int MAX_ACTIVE_HEROES = 5;

    private static List<Hero> heroesList = new List<Hero>(MAX_HEROES);
    private static List<Hero> activeHeroes = new List<Hero>(MAX_ACTIVE_HEROES);

    void Awake () {
    }

    void Start () {
	}
	
	void Update () {
	}

    public static void AddHero (Hero addition) {
        if (heroesList.Count < MAX_HEROES) {
            heroesList.Add(addition);
        } else {
            Debug.LogError("Number of heroes is at maximum capacity.");
        }
    }

    public static void SetHeroActive (Hero addition) {
        if (activeHeroes.Count < MAX_ACTIVE_HEROES) {
            activeHeroes.Add(addition);
        } else {
            Debug.LogError("Already have maximum number of active heroes.");
        }
    }

    /** Return a hero at the i-th index in heroesList. */
    public static Hero GetHero (int i) {
        if (heroesList[i] != null) {
            return heroesList[i];
        }
        return null;
    }

    public static void ClearActiveHeroes () {
        activeHeroes.Clear();
    }

    public static List<Hero> GetHeroList () {
        return heroesList;
    }

    public static List<Hero> GetActiveHeroes () {
        return activeHeroes;
    }

    public static int HeroTypeToInt (HeroType type) {
        switch (type) {
            case HeroType.Sentinel:
                return 0;
            case HeroType.Huntsman:
                return 1;
            case HeroType.Jouster:
                return 2;
            case HeroType.Patrol:
                return 3;
            case HeroType.Sharpshooter:
                return 4;
            case HeroType.Diviner:
                return 5;
            case HeroType.Bartender:
                return 6;
            case HeroType.Astronomer:
                return 7;
            default:
                return 8;
        }
    }

    public static HeroType IntToHeroType (int i) {
        if (i < 0 || i > 8) {
            Debug.LogError("Hero indices only range from 0-8. Index given: " + i);
        }
        switch (i) {
            case 0:
                return HeroType.Sentinel;
            case 1:
                return HeroType.Huntsman;
            case 2:
                return HeroType.Jouster;
            case 3:
                return HeroType.Patrol;
            case 4:
                return HeroType.Sharpshooter;
            case 5:
                return HeroType.Diviner;
            case 6:
                return HeroType.Bartender;
            case 7:
                return HeroType.Astronomer;
            default:
                return HeroType.Zealot;
        }
    }
}
