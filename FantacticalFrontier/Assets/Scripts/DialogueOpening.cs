using UnityEngine;
using System.Collections;

public class DialogueOpening : MonoBehaviour {

    public GameObject dialogueHandler;

    public Transform astronomerPrefab;
    public Transform sentinelPrefab;

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

        // ADD THE TWO DEFAULT HEROES
        Transform astro = Instantiate(astronomerPrefab);
        astro.name = "Sylvia";
        PlayerArmy.AddHero(astro.GetComponent<Hero>());
        Transform senti = Instantiate(sentinelPrefab);
        senti.name = "Rowen";
        PlayerArmy.AddHero(senti.GetComponent<Hero>());
	}
	
	// Update is called once per frame
	void Update () {
        if (messages != null && arrayStep < messages.Length) {
            if (!dialogueHandler.GetComponent<Dialogue>().GetBoxVisible()) {
                dialogueHandler.GetComponent<Dialogue>().ShowText(labels[arrayStep], messages[arrayStep], leftImages[arrayStep], rightImages[arrayStep]);
                arrayStep++;
            }
        } else if (arrayStep == messages.Length && !dialogueHandler.GetComponent<Dialogue>().GetBoxVisible()) {
            Application.LoadLevel("OpeningFight");
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
                int num_messages = 17;
                labels = new string[num_messages];
                messages = new string[num_messages];
                rightImages = new string[num_messages][];
                leftImages = new string[num_messages][];
                int i = 0;

                labels[i] = "Sylvia";
                messages[i] = "...I won't have you overstepping the line!";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_L_M";

                i = 1;
                labels[i] = "Rowen";
                messages[i] = "Please, I simply--";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_L";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L_M";

                i = 2;
                labels[i] = "Sylvia";
                messages[i] = "Need I remind you just exactly WHICH of us is the King's adviser?";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R_M";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L";

                i = 3;
                labels[i] = "Rowen";
                messages[i] = "ONE of the King's advisers.";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L_M";

                i = 4;
                labels[i] = "Rowen";
                messages[i] = "There have simply been too many cultist sightings to ignore! We must act quickly before their plan is realized!";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L_M";

                i = 5;
                labels[i] = "Sylvia";
                messages[i] = "Why are you telling me things I already know, and being so cryptic at the same time? Who is this exposition dump for?";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R_M";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L";

                i = 6;
                labels[i] = "Rowen";
                messages[i] = "Well you never know who may be listening. I'm just trying to build suspense.";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L_M";

                i = 7;
                labels[i] = "Sylvia";
                messages[i] = "Oh shut up, Rowen. Stop bothering me about these \"spooooky\" cultists of yours. If they truly are a problem, isn't it the job of YOUR men to deal with it?";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R_M";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L";

                i = 8;
                labels[i] = "Rowen";
                messages[i] = "This isn't a joke, Sylvia!";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L_M";

                i = 9;
                labels[i] = "Rowen";
                messages[i] = "Also, I sent you a letter ONE time! I had to send it to 10 people or else the spooky ghost--";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L_M";

                i = 10;
                labels[i] = null;
                messages[i] = "*CRASH*";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_L";

                i = 11;
                labels[i] = "Sylvia";
                messages[i] = "What was...";
                leftImages[i] = new string[1];
                leftImages[i][0] = "Astronomer_L_M";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Sentinel_R";

                i = 12;
                labels[i] = "Guard";
                messages[i] = "S-Sir! They're here!";
                leftImages[i] = new string[2];
                leftImages[i][0] = "Sentinel_R";
                leftImages[i][1] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Patrol_L_M";

                i = 13;
                labels[i] = "Guard";
                messages[i] = "Martha! What happened to you?!";
                leftImages[i] = new string[2];
                leftImages[i][0] = "Sentinel_R_M";
                leftImages[i][1] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Patrol_L";

                i = 14;
                labels[i] = "Guard";
                messages[i] = "N-No time... Just go... without me!";
                leftImages[i] = new string[2];
                leftImages[i][0] = "Sentinel_R";
                leftImages[i][1] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Patrol_L_M";

                i = 15;
                labels[i] = "Sylvia";
                messages[i] = "We have to get going. The king could be in danger!";
                leftImages[i] = new string[2];
                leftImages[i][0] = "Sentinel_R";
                leftImages[i][1] = "Astronomer_R_M";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Patrol_L";

                i = 16;
                labels[i] = "Rowen";
                messages[i] = "Agreed. Get to safety, Martha!";
                leftImages[i] = new string[2];
                leftImages[i][0] = "Sentinel_R_M";
                leftImages[i][1] = "Astronomer_R";
                rightImages[i] = new string[1];
                rightImages[i][0] = "Patrol_L";
                break;
        }
    }

    public bool IsFinished () {
        return finished;
    }
}
