using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{

    AudioSource[] mysounds;

    AudioSource starts;
    AudioSource works;

    // Start is called before the first frame update
    void Start()
    {
        mysounds = GetComponents<AudioSource>();

        starts = mysounds[0];
        works = mysounds[1];
        
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
