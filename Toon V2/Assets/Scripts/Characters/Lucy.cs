﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class Lucy : MonoBehaviour
{
    string localName = "Lucy";
    string playerName = "Player";
    public Cook cook;
    public CameraPan pan;
    public QueueController queue;
    public CustomerOrder order;

    private void Start()
    {
        order.CreateOrder();
        
    }
    public void Update()
    {
        if (cook.PieCompleted() == true && queue.currentCharacter == 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(LucyThanks());
        }

    }
    public void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    private DialogueSection LucyThanks()
    {
        Monologue b = new Monologue(localName, $"Next");
        Monologue a = new Monologue(localName, $"Thanks for the pie", b);
        return a;
    }
    private DialogueSection Conversation()
    {
     
        string occupation = "Plumber";
        Monologue sure = new Monologue(localName, "Thanks");
        Choices d = new Choices(localName, $"Can I get a Pie with {order.orderFilling}?", ChoiceList(Choice("Sure thing", sure)));
        Monologue fine = new Monologue(localName, "That's nice to hear.", d);
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!", d);
        Monologue bad = new Monologue(localName, "Sorry to hear that.", d);
        
        
        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));
        
        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);

        //queue.Next();

        return a;

    }

}