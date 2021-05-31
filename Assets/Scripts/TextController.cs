using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text text;
    public Animator callerImage;
    public bool writing = false;

    string SlowWriteStr = "";
    int SlowWrite_idx = 0;
    Canvas canvas;

    string[] Sequence = {};
    int seq_idx = 0;
    
    bool spaceDown;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        canvas = GetComponent<Canvas>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!spaceDown) {
                NextLine();
                spaceDown = true;
            }
        } else {
            spaceDown = false;
        }
    }


    void FixedUpdate()
    {
        if (SlowWrite_idx < SlowWriteStr.Length) {
            text.text += SlowWriteStr[SlowWrite_idx];
            SlowWrite_idx += 1;
        } else {
            callerImage.SetBool("IsTalking", false);
        }
    }

    void SlowWrite(string str) {
        text.text = "";
        SlowWriteStr = str;
        SlowWrite_idx = 0;
    }

    public void PrintSequence(string[] sequence) {
        canvas.enabled = true;
        writing = true;
        Sequence = sequence;
        seq_idx = 0;
        callerImage.SetBool("CallerPresent", true);
        NextLine();
    }

    public void SetCallerImage(string caller) {
        switch(caller) {
            case("Witch"):
                callerImage.SetInteger("Character", 1);
                break;
            case("Zombie"):
                callerImage.SetInteger("Character", 2);
                break;
            case("Ghost"):
                callerImage.SetInteger("Character", 3);
                break;
            case("Dracula"):
                callerImage.SetInteger("Character", 4);
                break;
            default:
                callerImage.SetInteger("Character", 0);
                break;
        }
    }

    void NextLine() {
        callerImage.SetBool("IsTalking", true);
        if (seq_idx < Sequence.Length) {
            SlowWrite(Sequence[seq_idx]);
            seq_idx += 1;
        } else {
            canvas.enabled = false;
            writing = false;
            callerImage.SetBool("CallerPresent", false);
        }
    }
}
