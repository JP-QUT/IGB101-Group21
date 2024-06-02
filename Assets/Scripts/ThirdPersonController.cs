using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPersonController : MonoBehaviour
{
    public static ThirdPersonController instance;
    private void Awake()
    {
        instance = this;
    }
    public int maxCoinNum;
    public int tongguanCoinum;
    int numCoin = 0;
    bool isCanMove = true;
    public float moveSpeed = 5f; // 移动速度
    public float rotationSpeed = 10f; // 旋转速度
    public float jumpHeight = 2;
    public Image _imgBg;
    public Image _imgFall;
    public Image _imgsucceed;
    public TextMeshProUGUI _textCoinNum;
    private CharacterController controller;
    private Vector3 moveDirection;
    Vector3 curPosition;
    private Animator animator;
    bool isFail = false;
    bool isSueeccd = false;
    private void Start()
    {
        curPosition = transform.position;
        isCanMove = false;
        _imgBg.gameObject.SetActive(true);
        _btnStart.onClick.AddListener(() =>
        {
            _imgBg.gameObject.SetActive(false);
            isCanMove = true;
            if (isFail || isSueeccd)
            {
                SceneManager.LoadScene(0);
            }
        });
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _textCoinNum.text = numCoin + "/" + maxCoinNum.ToString();
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
        if (isCanMove)
        {
            // 获取玩家输入
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // 计算移动方向
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
            movement = transform.TransformDirection(movement);
            movement *= moveSpeed;

            movement.y -= 9.8f;

            // 使用角色控制器移动
            //controller.Move(movement * Time.deltaTime);


            // 获取鼠标输入
            float mouseX = Input.GetAxis("Mouse X");

            // 计算旋转角度
            Quaternion rotation = Quaternion.Euler(0f, mouseX * rotationSpeed, 0f);

            // 旋转角色
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
                    animator.SetFloat("walk", 1);
                    animator.SetFloat("run", 1);
                }
                else
                {
                    animator.SetFloat("walk", 1);
                    animator.SetFloat("run", 0);
                }
            }
            else
            {
                animator.SetFloat("walk", 0);
                animator.SetFloat("run", 0);
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(transform.up * jumpHeight);
        }
    }

    //成功、失败
    public void OnSucceed()
    {
        _textCoinNum.text = numCoin + "/" + maxCoinNum.ToString();
        if (numCoin == tongguanCoinum)
        {
            //通关成功
            isSueeccd = true;
            _btnStart.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
            //_btnStart.gameObject.SetActive(false);
            _imgFall.gameObject.SetActive(false);
            _imgsucceed.gameObject.SetActive(true);
            _imgBg.gameObject.SetActive(true);
        }
    }
    public Button _btnStart;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "coin")
        {
            numCoin++;
            Destroy(hit.collider.gameObject.transform.parent.gameObject);
            OnSucceed();
        }
        else if (hit.gameObject.tag == "obstacle")
        {
            //输了
            isFail = true;
            isCanMove = false;
            _btnStart.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
            _imgFall.gameObject.SetActive(true);
            _imgsucceed.gameObject.SetActive(false);
            _imgBg.gameObject.SetActive(true);
        }
    }

}