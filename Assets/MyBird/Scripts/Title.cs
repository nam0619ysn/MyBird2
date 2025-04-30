using UnityEngine;
namespace MyBird
{
    public class Title : MonoBehaviour
    {
        #region Variable
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";
        [SerializeField] private bool isCheat = false;
        #endregion
        private void Update()
        {
#if UNITY_EDITOR 
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetDaceData();
            }
#endif
        }

        public void Play()
        {
            fader.FadeTo(loadToScene);
        }
            
        void ResetDaceData()
        {
            if (isCheat == false)
            {
                return;
            }
            Debug.Log("ResetData");
            PlayerPrefs.DeleteAll();
        }
        
    }
}