using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARPlacement : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject placementIndicator;
    GameObject instantiatedPrefab;
    Pose PlacementPose;
    ARRaycastManager raycastManager;
    bool placementIsValid = false;

    // Awake is called before Start
    void Awake() {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(instantiatedPrefab == null && placementIsValid && Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
            InstantiatePrefab();
            
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    void UpdatePlacementIndicator(){
        if(instantiatedPrefab == null && placementIsValid){
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position,PlacementPose.rotation);
        }else{
          placementIndicator.SetActive(false);  
        }
    }

    void UpdatePlacementPose(){
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f,0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementIsValid = hits.Count > 0;
        if(placementIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void InstantiatePrefab(){
        instantiatedPrefab = Instantiate(prefab, PlacementPose.position, PlacementPose.rotation);
    }
}
