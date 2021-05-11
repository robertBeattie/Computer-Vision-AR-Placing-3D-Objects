using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    float speed = 1f;
    [SerializeField] Joystick joystick;
    [SerializeField] CharacterController monster;

    private void Awake() {
        joystick = FindObjectOfType<Joystick>();
    }
    private void Start() {
        joystick.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(joystick == null){
            joystick = FindObjectOfType<Joystick>();
        }
        if(joystick != null){
            Vector2 joystickMovement = new Vector2(joystick.Horizontal * -1,joystick.Vertical *-1);
            //monster.Move(new Vector3(joystickMovement.x,0,joystickMovement.y) * speed * Time.deltaTime);
            transform.Translate(new Vector3(joystickMovement.x,0,joystickMovement.y) * speed * Time.deltaTime);
        }
        
    }
}
