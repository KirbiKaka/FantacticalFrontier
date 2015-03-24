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

	// Use this for initialization
	void Start () {
        LoadMessages(step);
	}
	
	// Update is called once per frame
	void Update () {
        if (messages != null && arrayStep < messages.Length) {
            if (!dialogueHandler.GetComponent<Dialogue>().GetBoxVisible()) {
                dialogueHandler.GetComponent<Dialogue>().ShowText(messages[arrayStep]);
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
                messages[0] = "TESTESTESTESTETSTEESD";
                messages[1] = "EVENMORE";
                break;
        }
    }

    public bool IsFinished () {
        return finished;
    }
}
