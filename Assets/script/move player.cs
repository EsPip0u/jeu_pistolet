using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{
    void Update ()
    {
        if (Keyboard.current.wKey.isPressed)
        {    
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);  // devant
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector3.left * 2 * Time.deltaTime);  // gauche
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector3.right * 2 * Time.deltaTime);    // droite
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.Translate(Vector3.back * 2 * Time.deltaTime);    // deriere
        }
    }
}