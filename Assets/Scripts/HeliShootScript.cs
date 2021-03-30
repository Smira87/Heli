using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeliShootScript : MonoBehaviour
{

    public Button rightFire;
    public Button leftFire;
    PhotonView view;
    public GameObject Bullet;

    public int force = 10;
    

 
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        GameObject rightFireButton = GameObject.Find("RightFire");
        GameObject leftFireButton = GameObject.Find("LeftFire");
        rightFire = rightFireButton.GetComponent<Button>(); 
        leftFire = leftFireButton.GetComponent<Button>(); 
        rightFire.onClick.AddListener(FireLeft);
        leftFire.onClick.AddListener(FireRight);

    }
 void FireLeft()
    {
         if (view.isMine)
        {
            view.RPC("shootBullet", PhotonTargets.All, transform.Find("ShootPosition").transform.position, transform.Find("ShootPosition").transform.rotation);
        }
    }
void FireRight()
    {
         if (view.isMine)
        {
            view.RPC("shootBullet", PhotonTargets.All, transform.Find("ShootPosition1").transform.position, transform.Find("ShootPosition").transform.rotation);
        }
    }
    
    // Update is called once per frame

    [PunRPC]
    void shootBullet(Vector3 Pos, Quaternion quaat)
    {
        GameObject GO = Instantiate(Bullet, Pos, quaat) as GameObject;
        GO.GetComponent<Rigidbody>().velocity = transform.TransformDirection((Vector3.right * force));
    }

    
}
