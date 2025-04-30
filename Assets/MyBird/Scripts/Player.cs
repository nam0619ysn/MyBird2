using UnityEngine;
using UnityEngine.Events;

namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variable
        private Rigidbody2D rb2D;
        public Animator animatior;
        private AudioSource audioSource;

        public DrawScore drawScore;

        private bool keyJump = false;
        [SerializeField]
        private float jumpForce = 5f;
        
        private Vector3 birdRotation;
        [SerializeField] private float upRotate = 2.5f;    
        [SerializeField] private float downRotate = -5f;   

        [SerializeField]private float moveSpeed = 5f;

        //대기
        //아래로 떨어지지 않을 만큼의 새를 유지
        [SerializeField] private float readyForce = 1f;

        //UI
        public GameObject readyUI;
        public GameObject resultUI;
        
        #endregion

        #region Unity Event Method


        void Start()
        {
            rb2D = this.GetComponent<Rigidbody2D>();
            audioSource = this.GetComponent<AudioSource>();
           
            
        }

        // Update is called once per frame
        void Update()
        {
            
            InputBird();

            if (GameManager.IsStart == false)
            {

                ReadyBird();
                return;
                    
            }
           
        
            RotateBird();

            MoveBird();
            if (keyJump)
            {               
                JumpBird();
               
                keyJump = false;
            }
            //this.transform.Translate(Vector3*Time.deltaTime*t 속도 공간)
        }
        private void FixedUpdate()
        {

            if (keyJump)
            {
                JumpBird();

                keyJump = false;
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //collsion 충돌 정보 가져오기
            if(collision.gameObject.tag == "Ground")
            {
               
                DieBirld();
            }
           
           
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
             //collsion 충돌 정보 가져오기
           if (collision.gameObject.tag == "Point")
           {           
                GameManager.Score++;
                //if(GameManager.Score %10== 10)
                //{
                     
                //}

                audioSource.Play();
                
                 Debug.Log($"점수 획득{GameManager.Score}");
           }
            else if (collision.gameObject.tag == "Pipe")
            {
                
                DieBirld();
            }
        }
       
        #endregion

        #region CustomMethod
        void InputBird()
        {
            if (GameManager.IsDeath)
                return;

#if UNITY_EDITOR
            //스페이스 왼클릭
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);
#else
            //터치 인풋
            if(Input.touchCount > 0)
            {
                //첫 터치만 처리
                Touch touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Began)
                {
                    keyJump |= true;
                }
            }
#endif
            
            //게임 기작전 점프키 눌리면
            if (GameManager.IsStart == false && keyJump == true)
            {

                StartMove();
            }
        }

        void JumpBird()
        {
            //rb2D.AddForce(Vector2.up * jumpForce());
            rb2D.linearVelocity = Vector2.up * jumpForce;   
        }

        void RotateBird()
        {
            float rotateSpeed = 0f;
            if (rb2D.linearVelocity.y > 0f)
            {
                rotateSpeed = upRotate;
            }
            else if (rb2D.linearVelocity.y < 0f)
            {
                rotateSpeed = downRotate;
            }
            birdRotation = new Vector3(0f, 0f,Mathf.Clamp( (birdRotation.z + rotateSpeed),-90f,30f));
            this.transform.eulerAngles = birdRotation;
        }
        void ReadyBird()
        {

            if (rb2D.linearVelocity.y<0f)
                 rb2D.linearVelocity = Vector2.up * readyForce;
        }
        void MoveBird()
        {

            if (GameManager.IsStart==false||GameManager.IsDeath==true)
                return;
            this.transform.Translate( Vector3.right * Time.deltaTime*moveSpeed, Space.World);

        } 
        void DieBirld()
        {
            if (GameManager.IsDeath)
                return;
            GameManager.IsDeath = true;
            animatior.enabled = false;
            rb2D.linearVelocity = Vector2.zero;

            //VFX SFX

            resultUI.SetActive(true);
        }
        //버드 이동시작
        void StartMove()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }
#endregion
    }
}