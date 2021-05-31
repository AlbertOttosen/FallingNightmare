using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    public TextController Text;
    public Animator phoneAnimator;

    string[] nextMessage;
    bool moving = true;
    public bool callEnded = false;

    public Canvas tutorial2;

    void Update() {
        if (!Text.writing && !phoneAnimator.GetBool("Ringing")) {
            EndCall();
        }
    }

    void FixedUpdate()
    {
        if (moving) {
            Move();
        }
    }

    public void IncomingCall(string[] message, string caller) {
        phoneAnimator.SetBool("Ringing", true);
        nextMessage = message;
        Text.SetCallerImage(caller);
        callEnded = false;
    }

    public void PickUp() {
        phoneAnimator.SetBool("Ringing", false);
        Text.PrintSequence(nextMessage);
        moving = false;
        tutorial2.enabled = false;

    }

    void EndCall() {
        moving = true;
        callEnded = true;
    }

    void Move() {

    }
}
