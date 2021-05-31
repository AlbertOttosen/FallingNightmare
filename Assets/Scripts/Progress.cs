using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public PC_Controller player;
    public Camera cam;
    public float zoomSpeed;
    public Spawner spawner;

    public int task = 0;
    public float zoomLevel;

    public Canvas credits;
    public Canvas tutorial;
    public Canvas tutorial2;

    //gameobjects
    public GameObject[] Eyes;
    public GameObject[] ShortList;
    public GameObject[] Task3;
    public GameObject[] Task4;
    public GameObject[] Task5;
    public GameObject[] Task6;
    public GameObject[] Task7;
    public GameObject[] PotionTask;

    // Start is called before the first frame update
    void Start()
    {
        NextTask();
    }

    // Update is called once per frame
    void Update()
    {
        switch (task)
        {
            case(1):
                if (Time.time > 5) {
                    tutorial.enabled = false;
                    tutorial2.enabled = true;
                    NextTask();
                }
                break;
            case(2):
            case(4):
            case(6):
            case(8):
            case(9):
            case(10):
            case(11):
            case(12):
            case(13):
            case(14):
            case(15):
            case(17):
            case(19):
            case(21):
            case(23):
                EndOnCallEnd();
                break;
            case(3):
                if (CheckInventory("Green Eyes", 3)) {
                    AllItemsCollected();
                }
                break;
            case(5):
                if (CheckInventory("Thumb", 2) && 
                    CheckInventory("Ring Finger", 1) && 
                    CheckInventory("Right Ear", 1) && 
                    CheckInventory("Left Ear", 1) && 
                    CheckInventory("Heart", 1) &&
                    CheckInventory("Big Foot", 2)) {
                        AllItemsCollected();
                }
                break;
            case(7):
                if (CheckInventory("Brain", 1) && CheckInventory("Coffin", 1)) {
                    AllItemsCollected();
                }
                break;
            case(16):
                if (CheckInventory("Wheel", 1)) {
                    AllItemsCollected();
                }
                break;
            case(18):
                if (CheckInventory("Hammer", 1) && CheckInventory("Wellies", 1)) {
                    AllItemsCollected();
                }
                break;
            case(20):
                if (CheckInventory("Bat", 1) && CheckInventory("Toilet Paper", 1)) {
                    AllItemsCollected();
                }
                break;
            case(22):
                if (CheckInventory("Alarm Clock", 1)) {
                    AllItemsCollected();
                }
                break;
            case(24):
                if (CheckInventory("Potion", 1)) {
                    EndGame();
                }
                break;
        }
        // zoom
        if (cam.orthographicSize > zoomLevel && zoomLevel == 5) {
            cam.orthographicSize = cam.orthographicSize - zoomSpeed;
        } else if (cam.orthographicSize < zoomLevel && zoomLevel == 10) {
            cam.orthographicSize = cam.orthographicSize + zoomSpeed;
        }
    }

    public void NextTask() {
        task++;
        switch (task)
        {
            case(1):
                //tutorial
                break;
            case(2):
                player.phoneScript.IncomingCall((new string[] {
                    "IIIHAHAHAAHHAHAAHAHAHAHAHAA!", 
                    "It's Witch here, you busy?", 
                    "Not that I care, I have to make a potion, and you're gonna help me!", 
                    "Firstly, get three Eyeballs", 
                    "You know, the green ones I like",
                    "Mix them up with the vile blue ones and I will put a curse on you to continue this nightmare forever!",
                    "Get it right this time and I just might consider breing you a potion that can wake you",
                    "...maybe",
                    "IIIHAHAHAA"}), "Witch");
                break;
            case(3):
                spawner.enabled = true;
                spawner.WhatToSpawn = Eyes;
                zoomLevel = 10;
                break;
            case(4):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "Hmmm...",
                    "That was disappointingly easy for you...",
                    "For it to add up with the work I'm gonna put into making that wake-up potion for you,",
                    "I'm gonna need your help with just another tiny potion.",
                    "Short list, longer than the last one I admit, but only a little.",
                    "I need:",
                    "Three fingers - two thumbs and one ringfinger",
                    "wait I'm not quite done, remember what I said",
                    "next: two ears, one of each of course",
                    "next: one heart, two feet, big ones, and...",
                    "What? This is way more than last time?",
                    "Don't be so whiny!",
                    "Fine, let's stop it there...",
                    "But only because I can't stand whining!",
                    "So I'll just be back for another favor later",
                    "IIIIIHAHAHAHAHAHAHAHAA"}), "Witch");
                break;
            case(5):
                spawner.enabled = true;
                spawner.WhatToSpawn = ShortList;
                spawner.SpawnRate = 1;
                zoomLevel = 10;
                break;
            case(6):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "I'm a little impressed, is someone helping you?",
                    "I hope not, 'cause then we don't have a deal",
                    "hm? I'm also bending the rules?",
                    "Why i never!",
                    "IIIHAHAHAHAHA",
                    "...",
                    "Get me a brain and a muffin",
                    "...wait, I read that wrong",
                    "COFFIN! That's right but you are welcome to bring me a muffin too",
                    "Hmmmmm?",
                    "That's not scary?",
                    "You prejudiced human!",
                    "You think I can't eat normal food, just like humans!?",
                    "I most certainly can! The ones bat-blood in it are my favorit!",
                    "...",
                    "you don't like bat blood?",
                    "What a weirdo! Now I have lost my appetite"}), "Witch");
                break;
            case(7):
                spawner.enabled = true;
                spawner.WhatToSpawn = Task3;
                zoomLevel = 10;
                spawner.SpawnRate = 2;
                break;
            case(8):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "Hello Ghost here!",
                    "I heard you're having complications with waking up and I wondered if you would like my help?",
                    "...",
                    "Great!",
                    "I heard scaring people can wake them up!",
                    "Allow me to be at your service. It just so happens that I'm an expert in scaring people",
                    "...",
                    "Great! Let's do it! I'll call you when you least expect it then!",
                    "Later"}), "Ghost");
                break;
            case(9):
                player.phoneScript.IncomingCall((new string[] {
                    "Good, good my little hopeful uglyness! Now wait for my call and i will have made a list of things we need for your wake-up potion!",
                    "Don't worry it's all eatible, totally safe!",
                    "So, pick up! Don't leave me hanging",
                    "Or I will get mad and withdraw the deal!",
                    "IIIIIHAHAHAHAHA!"}), "Witch");
                break;
            case(10):
                player.phoneScript.IncomingCall((new string[] {
                    "BOOO!",
                    "HA! Did i scare you?",
                    "no?",
                    "hmmm... I guess I'll try again later then?..."}), "Ghost");
                break;
            case(11):
                player.phoneScript.IncomingCall((new string[] {
                    "Weeeeaaaarrrrggggghhhhh....",
                    "yaaahh...",
                    "ZZZZzzzz",
                    "..."}), "Zombie");
                break;
            case(12):
                player.phoneScript.IncomingCall((new string[] {
                    "I've been calling and calling but it said you were busy in another call!?",
                    "Hope it was worth it, cause you're not getting that potion now!!",
                    "IIIHAHAHAHAHAHAHAA"}), "Witch");
                break;
            case(13):
                player.phoneScript.IncomingCall((new string[] {
                    "It's Dracula here!",
                    "Welcome to the Dracula-Online-World-Shop of...",
                    "Blood-shakes",
                    "Blood-cakes",
                    "Blood-shampoos",
                    "Blood-facemasks",
                    "Blood-nailpolish",
                    "Blood-makeup",
                    "Blood-icecream",
                    "Blood-sodas",
                    "uhhh...",
                    "and BLOOD!",
                    "What would you like to order?",
                    "...",
                    "Wake-up potion?",
                    "Is there blood in it?",
                    "no? Too bad..."}), "Dracula");
                break;
            case(14):
                player.phoneScript.IncomingCall((new string[] {
                    "BOOOOO!!",
                    "I must have gotten you this time!",
                    "no?",
                    "Huh...",
                    "why are you like this?",
                    "you're hurting my feelings",
                    "Don't you know it's super impolite to be unscared of a ghost?",
                    "I give up..."}), "Ghost");
                break;
            case(15):
                player.phoneScript.IncomingCall((new string[] {
                    "I'm sorry. I'm not home. Please leave a message...",
                    "hmmmm?",
                    "WHAT DO YOU MEAN, I CALLED YOU!?",
                    "WHY WOULD I DO THAT!?",
                    "...",
                    "I guess I did put in a lot of work and effort to create the list for your wake-up potion",
                    "It's just sitting here...",
                    "you still want it?",
                    "...",
                    "What do you mean, at what cost!?",
                    "When have i ever given you reason to doubt me!?",
                    "...",
                    "on second thought, don't answer that!",
                    "Now, first i need a Car Wheel!",
                    "What?",
                    "Yes yes, it's digestible even for you!",
                    "Now get on with it!"}), "Witch");
                break;
            case(16):
                spawner.enabled = true;
                spawner.WhatToSpawn = Task4;
                zoomLevel = 10;
                break;
            case(17):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "IIIAHHAAHAHAHAA! Perfect! Now, a Hammer and a Welly!"}), "Witch");
                break;
            case(18):
                spawner.enabled = true;
                spawner.WhatToSpawn = Task5;
                zoomLevel = 10;
                break;
            case(19):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "Good, very good",
                    "Lastly, a baseball bat and a roll of Toilet Paper!"}), "Witch");
                break;
            case(20):
                spawner.enabled = true;
                spawner.WhatToSpawn = Task6;
                zoomLevel = 10;
                break;
            case(21):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "Perfect!",
                    "Ooh! I almost forgot the most importent ingriedient!",
                    "a RED CLOCK of course!",
                    "Fetch me one of those"}), "Witch");
                break;
            case(22):
                spawner.enabled = true;
                spawner.WhatToSpawn = Task7;
                zoomLevel = 10;
                break;
            case(23):
                zoomLevel = 5;
                player.phoneScript.IncomingCall((new string[] {
                    "Great! Now,",
                    "I'll mix it all together for you",
                    "...",
                    "Hmmmm?",
                    "Feel sick?",
                    "No, no but you might need to use the bathroom when you wake!",
                    "IIHHHHAHAHAHAH",
                    "Wait for the potion to appear somewhere near you and take it",
                    "You will wake-up immediately!",
                    "IIIIIHHHHAHAHAHAHAHAHAHAHAHA!"}), "Witch");
                break;
            case(24):
                spawner.enabled = true;
                spawner.WhatToSpawn = PotionTask;
                break;
        }
    }

    bool CheckInventory(string ItemName, int requiredAmount) {
        try {
            return player.inventory[ItemName] >= requiredAmount; 
        }
        catch {
            player.inventory.Add(ItemName, 0);
        }
        return false;
    }

    void AllItemsCollected() {
        NextTask();
        spawner.enabled = false;
    }

    void EndOnCallEnd() {
        if (player.phoneScript.callEnded) {
            NextTask();
            player.CharacterAnimator.SetBool("Phoning", false);
            player.phoneScript.callEnded = false;
        }
    }

    void EndGame() {
        spawner.enabled = false;
        credits.enabled = true;
        player.gameEnded = true;
    }
}
