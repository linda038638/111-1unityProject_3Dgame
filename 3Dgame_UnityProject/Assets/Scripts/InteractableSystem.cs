﻿using UnityEngine;

namespace Misun
{
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("對話資料")]
        private DialogueData dataDialogue;

        private string nameTarget = "PlayerCapsule";

        private DialogueSystem dialogueSystem;
        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == nameTarget)
            {
                dialogueSystem.StartDialogue(dataDialogue);
            }
        }

    }

}

