using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] float cameraSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.right * cameraSpeed * Time.deltaTime); // pega o transform da camera e faz ela "andar" para a direita (sim, o mesmo do player bleh xD)
    }
}
