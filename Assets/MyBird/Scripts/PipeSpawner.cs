using System.Threading;
using UnityEngine;
namespace MyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        #region Varials
        public GameObject pipePrefab;

        [SerializeField] private float pipeTimer = 1f;
        private float countdown = 0f;

        [SerializeField] private float maxspawnY = 3.3f;
        [SerializeField] private float minspawnY = -1.6f;

        //스폰 가격 10개 통과할때 ㅏ마다 0.95~1.05-> 0,.9-_>1.0~->1.00 ->ㅐ.85~0.85
        [SerializeField] private float maxSpawnTime = 1.05f;
        [SerializeField] private float minSpawnTime = 0.9f;
        [SerializeField] private float levelingTime = 0.05f;
        
        #endregion

      
        private void Update()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;

            countdown += Time.deltaTime;
            if (countdown >= pipeTimer)
            {
                SpawnPipe();

                countdown = 0f;
                float levelingValue = (int)(GameManager.Score / 5) * levelingTime;
                pipeTimer = Random.Range(minSpawnTime - levelingValue, maxSpawnTime-levelingValue);
            }
        }

        void SpawnPipe()
        {
            float spawnY = this.transform.position.y + Random.Range(minspawnY, maxspawnY);
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);
            Instantiate(pipePrefab, this.transform.position, Quaternion.identity);
        }
    
    }
}