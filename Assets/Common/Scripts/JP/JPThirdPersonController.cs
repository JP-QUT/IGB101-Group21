using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JPThirdPersonController : MonoBehaviour
{
    // Adapted from Liqing's script to work in my level
    //public static JPThirdPersonController instance;
    //private void Awake()
    //{
    //    instance = this;
    //}
    public int maxCoinNum;
    public int tongguanCoinum;
    public int numCoin = 0;
    public bool isCanMove = true;
    public float moveSpeed = 5f; // �ƶ��ٶ�
    public float rotationSpeed = 10f; // ��ת�ٶ�
    public float jumpHeight = 2;
    public Image _imgBg;
    public Image _imgFall;
    public Image _imgsucceed;
    public TextMeshProUGUI _textCoinNum;
    public string nextScene; // Added by JP: To transition next scene
    private CharacterController controller;
    private Vector3 moveDirection;
    Vector3 curPosition;
    public Animator animator;
    public bool isFail = false;
    public bool isSueeccd = false;
    private void Start()
    {
        curPosition = transform.position;
        //isCanMove = false;
        //_imgBg.gameObject.SetActive(true);
        //_btnStart.onClick.AddListener(() =>
        //{
        //    _imgBg.gameObject.SetActive(false);
       //    isCanMove = true;
            //if (isFail || isSueeccd)
            //{
            //    SceneManager.LoadScene(scene);
            //}
        //});
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //_textCoinNum.text = numCoin + "/" + maxCoinNum.ToString();
        //_btnReply.onClick.AddListener(() =>
        //{
        //    numCoin = 0;
        //    _textCoinNum.text = numCoin + "/maxCoinNum";
        //    transform.position = curPosition;
        //    // }
        //    _btnReply.gameObject.SetActive(false);
        //    SceneManager.LoadScene(0);
        //});
    }

    public Camera camera;
    private void Update()
    {
        camera.transform.position = new Vector3(camera.transform.position.x, 4, camera.transform.position.z);
        if (isCanMove == true)
        {
            // ��ȡ�������
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // �����ƶ�����
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
            movement = transform.TransformDirection(movement);
            movement *= moveSpeed;

            movement.y -= 9.8f;

            // ʹ�ý�ɫ�������ƶ�
            //controller.Move(movement * Time.deltaTime);


            // ��ȡ�������
            float mouseX = Input.GetAxis("Mouse X");

            // ������ת�Ƕ�
            Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);

            // ��ת��ɫ
            transform.rotation *= rotation;

            float _walk = verticalInput;// Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
            bool run = false;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                run = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                run = false;
            }

            if (_walk > 0)
            {
                if (run)
                {
                    animator.SetBool("Walking", true);
                    animator.SetBool("Running", true);
                }
                else
                {
                    animator.SetBool("Walking", true);
                    animator.SetBool("Running", false);
                }
            }
            else
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Running", false);
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(transform.up * jumpHeight);
        }

        if(Input.GetKeyDown("e")){
            animator.SetBool("Waving", true);
        } else if(Input.GetKeyUp("e")){
            animator.SetBool("Waving", false);
        }

        if (Input.GetKey("a")) {
            transform.Rotate(0, -rotationSpeed * 15 * Time.deltaTime, 0, Space.World);
            animator.SetBool("Turn Left", true);
        } else if (Input.GetKey("d")) {
            transform.Rotate(0, rotationSpeed * 15 * Time.deltaTime, 0, Space.World);
            animator.SetBool("Turn Right", true);
        } else {
            animator.SetBool("Turn Left", false);
            animator.SetBool("Turn Right", false);
        }

        if (Input.GetKey("z"))
        {
            animator.SetBool("Fortnite", true);
        } else if (Input.GetKey("w"))
        {
            animator.SetBool("Fortnite", false);
        }

        if (Input.GetKey("x"))
        {
            animator.SetBool("Rumba", true);
        } else if (Input.GetKey("w"))
        {
            animator.SetBool("Rumba", false);
        }

        if (Input.GetKey("c"))
        {
            animator.SetBool("Jumping", true);
        } else if (Input.GetKey("w"))
        {
            animator.SetBool("Jumping", false);
        }

    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.tag == "coin")
    //    {
    //        numCoin++;
    //        Destroy(hit.collider.gameObject.transform.parent.gameObject);
    //        OnSucceed();
        //}
        //else if (hit.gameObject.tag == "obstacle")
        //{
        //    //����
        //    isFail = true;
        //    isCanMove = false;
        //    _btnStart.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
        //    _imgFall.gameObject.SetActive(true);
        //    _imgsucceed.gameObject.SetActive(false);
        //    _imgBg.gameObject.SetActive(true);
        //}
    //}
}