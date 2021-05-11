using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] ARPlacement placement;
    public void ResetGame() {
        
        placement.RestPlacement();
    }

}
