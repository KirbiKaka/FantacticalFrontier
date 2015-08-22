using UnityEngine;
using System.Collections;

public class DialogueOpeningFight : MonoBehaviour {

    public GameObject dialogueHandler;

    // The current step of dialogue. One array of messages.
    private int step = 0;
    // The current step in the array of messages.
    private int arrayStep = 0;
    // Finished with the current step. Stop sending messages until the next step.
    private bool finished = false;

    private string[] labels;
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
                dialogueHandler.GetComponent<Dialogue>().ShowText(labels[arrayStep], messages[arrayStep], leftImages[arrayStep], rightImages[arrayStep]);
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
                // Set this to the number of messages.
                int num_messages = 1;
                labels = new string[num_messages];
                messages = new string[num_messages];
                rightImages = new string[num_messages][];
                leftImages = new string[num_messages][];
                int i = 0;

                labels[i] = "Rowen";
                messages[i] = "What's going on here?!";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Sentinel_R_M";
                break;
        }
    }

    public bool IsFinished () {
        return finished;
    }
}

