
using UnityEngine;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/
public class Interactable : MonoBehaviour
{
    public float radius = 3f;       // How close do we need to be to interact?
    bool isFocus=false;
    bool hasInteracted = false;
    Transform player;
    public Transform interactionTransform;
    
    public virtual void Interact(){        
 //interact method for obejcts, items and everything-thats why we use the virtual-we will override this method on items/animals/objects etc
       // Debug.Log("Interacting with "+ transform.name);
    }
    void Update(){
        if(isFocus && !hasInteracted)
        {
            float distance= Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
              //  Debug.Log("INTERACT");
                Interact();
                hasInteracted=true;
        }
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted=false;
    }
    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted=false;
    }
   // Draw our radius in the editor
    void OnDrawGizmosSelected(){
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
