using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Para ajustar variable en el inspector [SerializedField]
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    // Representa límite de hasta donde se pueden mover las paletas
    private float yBound = 3.75f;

    void Update()
    {
        float movement;
        if (isPaddle1)
        {
            // Devuelve 1 o -1 dependiendo si se apreta la tecla de arriba o abajo
            // Con Kinematic no hay problema con aplicar movimiento directamente con el componente Transform
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        // Se ocupa Time.deltaTime para lograr un movimiento independiente del framerate
        // Parámetros ( x, y, z )
        //transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);

        // Unity no permite modificar directamente el valor de y de transform
        //transform.position.y = yBound;

        // Por lo que se opta por ocupar un vector
        Vector2 paddlePosition = transform.position;
        // Valores mímimo y máximo
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}
