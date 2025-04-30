using UnityEngine;
namespace MyBird
{
    public class CameraController : MonoBehaviour
    {
        #region Variables
        public Transform player;

        [SerializeField] private float offsetX=1.5f;
        #endregion
        private void Start()
        {
            FollowPlayer();
        }
        private void Update()
        {
            FollowPlayer();
        }

        void FollowPlayer()
        {
           this.transform.position = new Vector3(player.position.x + offsetX, transform.position.y, this.transform.position.z);
          
           //this.transform.position = player.position;
        }

    }
}