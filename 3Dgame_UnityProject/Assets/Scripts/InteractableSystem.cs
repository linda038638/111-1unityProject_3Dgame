using UnityEngine;

namespace Misun
{
    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("��ܸ��")]
        private DialogueData dataDialogue;

        private string nameTarget = "PlayerCapsule";

        private DialogueSystem dialogueSystem;
        private void Awake()
        {
            dialogueSystem = GameObject.Find("�e����ܨt��").GetComponent<DialogueSystem>();
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

