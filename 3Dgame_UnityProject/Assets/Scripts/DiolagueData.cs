using UnityEngine;

namespace Misun
{
    /// <summary>
    /// 對話資料
    /// </summary>
    [CreateAssetMenu(menuName = "Misun/Dialogue Data", fileName = "New Dialogue Data")]
    public class DiolagueData : ScriptableObject
    {
        [Header("對話者名稱")]
        public string dialogueName;
        [Header("對話者內容"), TextArea(2,10)]
        public string[] dialogueContents;
    
    
    
    }

}
