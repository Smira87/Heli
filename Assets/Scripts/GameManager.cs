using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;



public class GameManager : MonoBehaviour
{
    

    //public DroneController _DroneController;
    
    public  GameObject env;
    public Button _StartButton;

    
    //AR
    public ARRaycastManager _RaycastManager;
    public ARPlaneManager _PlaneManager;
    List<ARRaycastHit> _HitRelult = new List<ARRaycastHit>();

    
    public bool envPlaced;
   


    // Start is called before the first frame update
    void Start()
    {
        
        _StartButton.onClick.AddListener(EventOnClickStartButton);
        
    }
   
        void FixedUpdate()
    {

        
        if(!envPlaced)
        {
            UpdateAR();
        }

    }
    
    
    void UpdateAR()
    {
        Vector2 positionScreenSpace = Camera.current.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        _RaycastManager.Raycast(positionScreenSpace, _HitRelult, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds);
        if(_HitRelult.Count > 0)
        {
            if(_PlaneManager.GetPlane(_HitRelult[0].trackableId).alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
            {
                Pose pose = _HitRelult[0].pose;
                
                env.transform.position = pose.position;
                env.SetActive(true);
            }
        }
    }

    
    void EventOnClickStartButton()
    {
            
            envPlaced = true;
         
        
    }
  
        

}

