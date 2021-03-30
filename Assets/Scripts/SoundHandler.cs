using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{

    AudioSource[] mysounds;
    public Button rightFire;
    public Button leftFire;
    AudioSource starts;
    AudioSource works;
    AudioSource fires;
    // Start is called before the first frame update
    void Start()
    {
        GameObject rightFireButton = GameObject.Find("RightFire");
        GameObject leftFireButton = GameObject.Find("LeftFire");
        rightFire = rightFireButton.GetComponent<Button>(); 
        leftFire = leftFireButton.GetComponent<Button>(); 

        rightFire.onClick.AddListener(PlayFires);
        leftFire.onClick.AddListener(PlayFires);
        
        
        mysounds = GetComponents<AudioSource>();

        starts = mysounds[0];
        works = mysounds[1];
        fires = mysounds[2];
        
        
        StartCoroutine(Sound());
        

    }
     IEnumerator Sound()
    {
        yield return new WaitForSeconds(0.01f);
        PlayStarts();
        yield return new WaitForSeconds(4f);
        StopStarts();
        PlayWorks();  

    }

    public void PlayFires()
    {
        fires.Play();
    }

    public void PlayStarts()
    {
        starts.Play();
    }
    public void StopStarts()
    {
        starts.Stop();
    }
    public void PlayWorks()
    {
        works.Play();
    }
    public void StopWorks()
    {
        works.Stop();
    }
    // Update is called once per frame
   
}
