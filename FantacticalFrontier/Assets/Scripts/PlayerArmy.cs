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

    private static List<Hero> heroesList;

    void Awake () {
        heroesList = new List<Hero>(20);
    }

	void Start () {
	}
	
	void Update () {
	}

    public static void AddHero (Hero addition) {
        heroesList.Add(addition);
    }

    public static List<Hero> GetHeroList () {
        return heroesList;
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
