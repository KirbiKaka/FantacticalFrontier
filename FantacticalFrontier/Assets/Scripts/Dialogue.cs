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
                for (int i = 0; i < leftImages.Length; i++) {
                    GUI.DrawTexture(new Rect(i * 150, Screen.height / 3, Screen.width / 5, Screen.height / 3),
                        GetTextureFromString(leftImages[i]),
                        ScaleMode.ScaleToFit);
                }
            }
            if (rightImages != null) {
                for (int i = 0; i < rightImages.Length; i++) {
                    GUI.DrawTexture(new Rect(Screen.width - 200 - i * 150, Screen.height / 3, Screen.width / 5, Screen.height / 3),
                        GetTextureFromString(rightImages[i]),
                        ScaleMode.ScaleToFit);
                }
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
        switch (s) {
            case "Bartender":
                return bartender;
            case "Sentinel":
                return sentinel;
            case "Sharpshooter":
                return sharpshooter;
            case "Astronomer":
                return astronomer;
            case "Patrol":
                return patrol;
            case "Zealot":
                return zealot;
        }
        return null;
    }

    public bool GetBoxVisible () {
        return boxVisible;
    }
    public void SetBoxVisible (bool display) {
        boxVisible = display;
    }

}
