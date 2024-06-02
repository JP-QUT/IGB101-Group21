using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button _btnStart;
     //ThirdPersonController third;
    // Start is called before the first frame update
    void Start()
    {
       //third = ThirdPersonController.instance;
        //third.isCanMove = false;
        _btnStart.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
           // third.isCanMove = true;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
