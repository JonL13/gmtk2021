using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BeginMessaging : MonoBehaviour
{
    public TextMeshProUGUI beginMessaging;

    private int messageCursor = 0;
    private string[] beginGameMessage = new string[] {
        "Press ENTER",

        "Welcome to Refuel\nYour mission is to join with towers to exchange fuel",

        "Use WASD or the ARROW KEYS to move\n" +
        "Use LMB or CTRL to give fuel\n" +
        "Use RMB or ALT to take fuel\n" +
        "Press ENTER to start"
    };

    void Start() {
        beginMessaging.SetText(beginGameMessage[messageCursor]);
        messageCursor += 1;
    }

    void Update(){
        if (Input.GetButtonDown("Submit")) {
            if (messageCursor < beginGameMessage.Length) {
                beginMessaging.SetText(beginGameMessage[messageCursor]);
                messageCursor += 1;
            } else {
                SceneManager.LoadScene(1);
            }
        }
    }
}
