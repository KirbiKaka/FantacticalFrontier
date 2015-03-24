using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public Texture dialogueBox;
    public Texture sentinel;
    public Texture bartender;
    public Texture astronomer;
    public Texture patrol;
    public Texture sharpshooter;
    public Texture zealot;

    private bool boxVisible = false;
    private string message = "";

    // Character images during dialogue.
    private string[] leftImages;
    private string[] rightImages;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0, Screen.height * 2 / 3, 0);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1")) {
            if (boxVisible) {
                SetBoxVisible(false);
            }
        }
	}

    void OnGUI () {
        if (boxVisible) {
            if (leftImages != null) {
                // TODO iterate through and draw each image with a slight offset, use GetTextureFromString
            }
            GUI.DrawTexture(new Rect(0, Screen.height * 2 / 3, Screen.width, Screen.height / 3), dialogueBox, ScaleMode.ScaleToFit);
            GUI.Label(new Rect(0, Screen.height * 2 / 3, Screen.width, Screen.height / 3), message);
        }
    }

    void OnMouseClick () {
    }

    public void ShowText (string m, string[] left = null, string[] right = null) {
        SetBoxVisible(true);
        message = m;
        leftImages = left;
        rightImages = right;
    }

    private Texture GetTextureFromString (string s) {
        // TODO
        return null;
    }

    public bool GetBoxVisible () {
        return boxVisible;
    }
    public void SetBoxVisible (bool display) {
        boxVisible = display;
    }

}
