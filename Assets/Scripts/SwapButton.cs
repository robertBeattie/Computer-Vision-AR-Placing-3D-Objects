using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SwapButton : MonoBehaviour
{
    [SerializeField] ARPlacement placement;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject beholder;
    [SerializeField] GameObject mimic;

    bool isMimic = true;
    public void Swap(){
        if(isMimic){
            text.SetText("Beholder");
            placement.SetMonster(beholder);
            isMimic = false;
        }else{
            text.SetText("Mimic");
            placement.SetMonster(mimic);
            isMimic = true;
        }
    }
}
