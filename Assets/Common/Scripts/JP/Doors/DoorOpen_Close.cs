using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
            GetComponent<Animation>().Play();
        
    }

    ///private void OnTriggerEnter(Collider otherObject)
   // {
    //    if(otherObject.transform.tag == "Player")
    //    {
      //      GetComponent<Animation>().Play();
    //    }
    //}

    //private void Actions()
    //{
    //    if(Input.GetKeyDown("f")){
//            GetComponent<Animation>().Play();
    //    } else if(Input.GetKeyUp("f")){
    //       anim.SetBool("Waving", false);
    //    }
    //}
}
