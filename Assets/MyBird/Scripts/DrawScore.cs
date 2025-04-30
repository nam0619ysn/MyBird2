using TMPro;
using UnityEngine;
namespace MyBird
{
    public class DrawScore : MonoBehaviour
    {
        #region Varials
        public TextMeshProUGUI scoreText;
        #endregion

        // Update is called once per frame
        void Update()
        {
            scoreText.text = GameManager.Score.ToString();
        }
    }
}
