using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public Texture dialogueBox;
    public GUIStyle style;
    public GUIStyle labelStyle;

    private bool boxVisible = false;
    private string label = "";
    private string message = "";

    // Character images during dialogue.
    private string[] leftImages;
    private string[] rightImages;

    private Color darkened = new Color(.5f, .5f, .5f);
    private Color normal = new Color(1, 1, 1);

	// Use this for initialization
	void Start () {
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
            // Draw character images. Main talkers are always drawn last.
            if (leftImages != null) {
                for (int i = leftImages.Length - 1; i >= 0; i--) {
                    GUI.color = darkened;
                    if (!IsMainTalker(leftImages[i])) {
                        GUI.DrawTexture(new Rect((leftImages.Length - i) * Screen.width / 11, Screen.height / 3, Screen.width / 5, Screen.height / 3),
                            GetTextureFromString(leftImages[i]),
                            ScaleMode.ScaleToFit);
                    }
                }
                for (int i = leftImages.Length - 1; i >= 0; i--) {
                    GUI.color = normal;
                    if (IsMainTalker(leftImages[i])) {
                        GUI.DrawTexture(new Rect((leftImages.Length - i) * Screen.width / 11, Screen.height / 3, Screen.width / 5, Screen.height / 3),
                            GetTextureFromString(leftImages[i]),
                            ScaleMode.ScaleToFit);
                    }
                }
            }
            if (rightImages != null) {
                for (int i = rightImages.Length - 1; i >= 0; i--) {
                    GUI.color = darkened;
                    if (!IsMainTalker(rightImages[i])) {
                        GUI.DrawTexture(new Rect(Screen.width - Screen.width / 5 - (rightImages.Length - i) * Screen.width / 11, Screen.height / 3, Screen.width / 5, Screen.height / 3),
                            GetTextureFromString(rightImages[i]),
                            ScaleMode.ScaleToFit);
                    }
                }
                for (int i = rightImages.Length - 1; i >= 0; i--) {
                    GUI.color = normal;
                    if (IsMainTalker(rightImages[i])) {
                        GUI.DrawTexture(new Rect(Screen.width - Screen.width / 5 - (rightImages.Length - i) * Screen.width / 11, Screen.height / 3, Screen.width / 5, Screen.height / 3),
                            GetTextureFromString(rightImages[i]),
                            ScaleMode.ScaleToFit);
                    }
                }
            }
            // Draw box and text.
            GUI.color = normal;
            GUI.DrawTexture(new Rect(0, Screen.height * 2 / 3, Screen.width, Screen.height / 3), dialogueBox, ScaleMode.ScaleToFit);
            if (label != null) {
                GUI.Label(new Rect(Screen.width / 12 + Screen.width / 32, Screen.height * 2 / 3 + Screen.height / 32, Screen.width, Screen.height / 3), label, labelStyle);
                GUI.Label(new Rect(Screen.width / 12, Screen.height * 2 / 3 + Screen.height * 3 / 32, Screen.width * 6 / 8, Screen.height / 3), message, style);
            } else {
                GUI.Label(new Rect(Screen.width / 12, Screen.height * 2 / 3 + Screen.height / 32, Screen.width * 6 / 8, Screen.height / 3), message, style);
            }
        }
    }

    void OnMouseClick () {
    }

    public void ShowText (string l, string m, string[] left = null, string[] right = null) {
        SetBoxVisible(true);
        label = l;
        message = m;
        leftImages = left;
        rightImages = right;
    }

    public void ShowText (string m, string[] left = null, string[] right = null) {
        SetBoxVisible(true);
        label = null;
        message = m;
        leftImages = left;
        rightImages = right;
    }

    private bool IsMainTalker (string s) {
        return s.Substring(s.Length - 2).Equals("_M");
    }

    private Texture GetTextureFromString (string s) {
        if (s.Substring(s.Length - 2).Equals("_M")) {
            s = s.Substring(0, s.Length - 2);
        }
        switch (s) {
            case "Bartender_R":
                return bartender_R;
            case "Bartender_L":
                return bartender_L;
            case "Sentinel_R":
                return sentinel_R;
            case "Sentinel_L":
                return sentinel_L;
            case "Sharpshooter_R":
                return sharpshooter_R;
            case "Sharpshooter_L":
                return sharpshooter_L;
            case "Astronomer_R":
                return astronomer_R;
            case "Astronomer_L":
                return astronomer_L;
            case "Patrol_R":
                return patrol_R;
            case "Patrol_L":
                return patrol_L;
            case "Zealot_R":
                return zealot_R;
            case "Zealot_L":
                return zealot_L;
        }
        return null;
    }

    public bool GetBoxVisible () {
        return boxVisible;
    }
    public void SetBoxVisible (bool display) {
        boxVisible = display;
    }

    public Texture sentinel_R;
    public Texture sentinel_L;
    public Texture bartender_R;
    public Texture bartender_L;
    public Texture astronomer_R;
    public Texture astronomer_L;
    public Texture patrol_R;
    public Texture patrol_L;
    public Texture sharpshooter_R;
    public Texture sharpshooter_L;
    public Texture zealot_R;
    public Texture zealot_L;

}
