using UnityEngine;

namespace MyBird
{
    public class GroundMove : MonoBehaviour
    {
        #region Variable

        [SerializeField] private float moveSpeed = 5f;

        #endregion
        private void Start()
        {
            
        }
        private void Update()
        {
            Move();

        }
        void Move()
        {
            if (GameManager.IsStart==false)
                return;

            float speed = (GameManager.IsDeath) ? moveSpeed / 4f : moveSpeed;

            transform.Translate(Vector3.left * Time.deltaTime *speed, Space.World);

            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 8.4f, transform.localPosition.y , transform.localPosition.z);
            }
        }
    }
}