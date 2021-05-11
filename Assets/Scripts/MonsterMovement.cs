using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] float speed = 7f;
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
        Vector2 joystickMovement = new Vector2(joystick.Horizontal,joystick.Vertical);
        //monster.Move(new Vector3(joystickMovement.x,0,joystickMovement.y) * speed * Time.deltaTime);
        transform.Translate(new Vector3(joystickMovement.x,0,joystickMovement.y) * speed * Time.deltaTime);
    }
}
