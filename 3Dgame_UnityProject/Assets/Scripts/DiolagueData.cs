using UnityEngine;

namespace Misun
{
    /// <summary>
    /// ��ܸ��
    /// </summary>
    [CreateAssetMenu(menuName = "Misun/Dialogue Data", fileName = "New Dialogue Data")]
    public class DiolagueData : ScriptableObject
    {
        [Header("��ܪ̦W��")]
        public string dialogueName;
        [Header("��ܪ̤��e"), TextArea(2,10)]
        public string[] dialogueContents;
    
    
    
    }

}
