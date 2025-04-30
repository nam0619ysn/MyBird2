using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyBird
{
    public class ResultUI : MonoBehaviour
    {

        #region Variant        
        public SceneFader fader;
        [SerializeField] private string sceneToLoad = "Title";

        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI score;
        public TextMeshProUGUI newText;
        #endregion

        // Update is called once per frame
        private void OnEnable()
        {
            
            if(GameManager.Score>GameManager.BestScore)
            {
                GameManager.BestScore = GameManager.Score;
                PlayerPrefs.SetInt("BestScore",GameManager.Score);
                newText.text = "NEW";
            }
            else
            {
                newText.text = "";
            }

            bestScore.text = GameManager.BestScore.ToString();
            score.text = GameManager.Score.ToString();
        }
        public void Retry()
        {
           

            //해당(자기 자신) 씬을 다시 부른다
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);    //씬이름으로 로드
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    //빌드 인덱스로 로드
            fader.FadeTo( SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            fader.FadeTo(sceneToLoad);
        }
    }
}