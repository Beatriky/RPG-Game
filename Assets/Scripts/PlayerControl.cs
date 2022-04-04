using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControl : MonoBehaviour
{
    public Interactable focus;      // Our current focus: Item, Enemy etc.

    public LayerMask movementMask;  // Filter out everything not walkable

    Camera cam;
    PlayerMotor motor;

    void Start()
    {
        cam=Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        // If we press left mouse
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if(Physics.Raycast(ray,out hit,100))     //range 100
        { 
            motor.MoveToPoint(hit.point);        //Move our player to what we hit    
            RemoveFocus();                       //Stop focusing any obj

            //Debug.Log("we hit"+hit.collider.name+" "+hit.point);  
        }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

             if(Physics.Raycast(ray,out hit,100))   ///range 100
             { 
                motor.MoveToPoint(hit.point);
                Interactable interectable = hit.collider.GetComponent<Interactable>();
                //check if we hit an interectable and if we did set it as our focus

                 if(interectable != null)
                 {
                    SetFocus(interectable);
                 }
             }
        }
    }

    void SetFocus(Interactable newFocus)
    {  if(newFocus != focus)
         {
             if(focus != null)
              focus.OnDefocused();
              
         focus = newFocus;
         motor.FollowTarget(newFocus);   //for tracking a target
         }

          newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {   
        if(focus != null)
              focus.OnDefocused();
        focus=null;
        motor.StopFollowingTarget();
    }
}