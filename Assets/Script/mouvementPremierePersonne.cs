using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementPremierePersonne : MonoBehaviour
{
    public float vitesseRotationSourie; //sensibilite   
    public float vitesseDeplacement; //vitesse de deplacement
    public Rigidbody rb; //Rigidbody  
    public float forceSaut;  

    bool auSol; //joueur au sol

   
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         //Gestion D�placement
            float tourne = Input.GetAxis("Mouse X") * vitesseRotationSourie * Time.deltaTime; // intensité déplacement souris * vitesse de base et le temps
            transform.Rotate(0f, tourne, 0f); // envoie de cette valeur dans le personnage pour le faire tourné

            float axeH = Input.GetAxisRaw("Horizontal") * vitesseDeplacement; // déplacement horizontal
            float axeV = Input.GetAxisRaw("Vertical") * vitesseDeplacement; // déplacement vertical
        
            rb.velocity = (transform.forward * axeV) + (transform.right * axeH) + new Vector3(0, rb.velocity.y, 0); // augmentation de la velocite selon les paramètre plus haut

            //Gestion du Saut
            RaycastHit infoCollision;
            // la bool devient true si le raycast touche quelque chose en dessous du personnage
            auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.5f, 0), 0.2f, -Vector3.up, out infoCollision, 0.5f); 
            // si le joueur appuie sur espace et qu'il est au sol,
            if (Input.GetKeyDown(KeyCode.Space) && auSol)
            {
                // rb.velocity += new Vector3(0, forceSaut, 0); //on le boost dans les airs
                GetComponent<Rigidbody>().velocity = new Vector2(0, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * forceSaut));
                print("je saute");
            }    
    }
}
