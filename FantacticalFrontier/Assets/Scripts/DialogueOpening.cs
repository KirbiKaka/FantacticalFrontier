using UnityEngine;
using System.Collections;

public class DialogueOpening : MonoBehaviour {

    public GameObject dialogueHandler;

    // The current step of dialogue. One array of messages.
    private int step = 0;
    // The current step in the array of messages.
    private int arrayStep = 0;
    // Finished with the current step. Stop sending messages until the next step.
    private bool finished = false;
    private string[] messages;
    private string[][] leftImages;
    private string[][] rightImages;

	// Use this for initialization
	void Start () {
        LoadMessages(step);
	}
	
	// Update is called once per frame
	void Update () {
        if (messages != null && arrayStep < messages.Length) {
            if (!dialogueHandler.GetComponent<Dialogue>().GetBoxVisible()) {
                dialogueHandler.GetComponent<Dialogue>().ShowText(messages[arrayStep], leftImages[arrayStep], rightImages[arrayStep]);
                arrayStep++;
            }
        }
	}

    public void NextStep (int s = 10) {
        step += s;
        finished = false;
        LoadMessages(step);
    }

    private void LoadMessages (int s) {
        switch (s) {
            case 0:
                messages = new string[2];
                rightImages = new string[2][];
                leftImages = new string[2][];
                messages[0] = "TESTESTESTESTETSTEESD";
                leftImages[0] = new string[2];
                leftImages[0][0] = "Bartender";
                leftImages[0][1] = "Sentinel";
                rightImages[0] = new string[1];
                rightImages[0][0] = "Sharpshooter";
                messages[1] = "EVENMORE";
                rightImages[1] = new string[2];
                rightImages[1][0] = "Sharpshooter";
                rightImages[1][1] = "Bartender";
                break;
        }
    }

    public bool IsFinished () {
        return finished;
    }
}
