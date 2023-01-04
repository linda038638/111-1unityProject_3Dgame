using UnityEngine;
using UnityEngine.Events;

namespace Misun
{
    /// <summary>
    /// 互動系統
    /// 當玩家與物件互動時，觸發對話、事件
    /// 
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {

       
        [SerializeField, Header("對話資料")]
        private DialogueData dataDialogue;
        [SerializeField, Header("對話結束後的事件")]
        private UnityEvent onDiaogueFinish;
        [SerializeField, Header("啟動道具")]
        private GameObject propActive;
        [SerializeField, Header("啟動後對話資料")]
        private DialogueData dataDialogueActive;
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
                if(propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDiaogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive);
                }
                
            }
        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
            Debug.Log("do!");
        }

    }

}

