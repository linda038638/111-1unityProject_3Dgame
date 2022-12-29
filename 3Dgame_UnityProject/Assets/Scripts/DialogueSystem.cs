using UnityEngine;
using TMPro;
using System.Collections;

namespace Misun
{
    /// <summary>
    /// 對話系統,有打字機效果,對話完成之後才可以跳到下一步(下個對話)
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)]
        private float dialogueTntervalTime = 0.1f;
        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;


        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueTntervalTime);
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContents;
        private GameObject goToNext;
        #endregion


        #region 預處理事件
        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者姓名").GetComponent<TextMeshProUGUI>();
            textContents = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            goToNext = GameObject.Find("下一步");

            StartDialogue(dialogueOpening);


        }
        #endregion


        public void StartDialogue(DialogueData data)
        {
            StartCoroutine(TypeEffect(data));

        }


        private IEnumerator TypeEffect(DialogueData data)
        {
            StartCoroutine(FadeGroup(true));

            textName.text = data.dialogueName;

            for (int i = 0; i < data.dialogueContents.Length; i++)
            {
                goToNext.SetActive(false);
                textContents.text = "";
                for (int j = 0; j < data.dialogueContents[i].Length; j++)
                {
                    textContents.text += data.dialogueContents[i][j];
                    yield return dialogueInterval;
                }
                
                goToNext.SetActive(true);

                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    yield return null;
                }

            }

            StartCoroutine(FadeGroup(false));

        }


        #region FadeIn

        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            float fadeTime = fadeIn ? +0.1f : -0.1f;
            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += fadeTime;
                yield return new WaitForSeconds(0.04f);
            }

        }
        #endregion



    }
}
