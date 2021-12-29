using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementCam : MonoBehaviour
{
    public float sensibilite;// sensibilité caméra du joueur
    float xRotation = 0f; //Rotation X
    float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // le curseur est blocké
    }

    void Update()
    {
       float camY = Input.GetAxis("Mouse Y") * sensibilite * 1.5f * Time.deltaTime; // renvoie une valeur qui dépend dela direction du mouvement de la souris

        xRotation -= camY; // Cette valeur est inversé 
        xRotation = Mathf.Clamp(xRotation, -70f, 65f); //et contraint en sa hauteur

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // et finalement appliqué à la caméra

    }
}
