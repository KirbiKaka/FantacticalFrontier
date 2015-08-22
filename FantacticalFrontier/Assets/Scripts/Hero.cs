using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public string name;
    public PlayerArmy.HeroType type;
    public int level;

    private bool visible = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool GetVisible () {
        return visible;
    }

    public void SetVisible (bool vis) {
        visible = vis;
        if (transform.GetComponent<SpriteRenderer>() != null) {
            if (visible) {
                transform.GetComponent<SpriteRenderer>().enabled = true;
            } else {
                transform.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
