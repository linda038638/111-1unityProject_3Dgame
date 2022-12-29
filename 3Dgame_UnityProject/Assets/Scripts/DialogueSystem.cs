using UnityEngine;
using TMPro;
using System.Collections;

namespace Misun
{
    /// <summary>
    /// ��ܨt��,�����r���ĪG,��ܧ�������~�i�H����U�@�B(�U�ӹ��)
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region ��ưϰ�
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)]
        private float dialogueTntervalTime = 0.1f;
        [SerializeField, Header("�}�Y���")]
        private DialogueData dialogueOpening;


        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueTntervalTime);
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContents;
        private GameObject goToNext;
        #endregion


        #region �w�B�z�ƥ�
        private void Awake()
        {
            groupDialogue = GameObject.Find("�e����ܨt��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̩m�W").GetComponent<TextMeshProUGUI>();
            textContents = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            goToNext = GameObject.Find("�U�@�B");

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
