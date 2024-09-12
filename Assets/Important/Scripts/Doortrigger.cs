using UnityEngine;

public class Doortrigger : MonoBehaviour
{
    [SerializeField] private Transform doorPivot = null;
    [SerializeField] private Animator door = null;
    
    [SerializeField] private bool doorClosed = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            // Debug.Log("active");
            // Debug.Log(doorPivot.rotation.eulerAngles.y);
            
            if (doorClosed && doorPivot.rotation.eulerAngles.y == 0f)
            {
                if (gameObject.CompareTag("LeftDoorTrigger"))
                {
                    door.Play("DoorOpenLeft");
                }
                if (gameObject.CompareTag("RightDoorTrigger"))
                {
                    door.Play("DoorOpenRight");
                }

                doorClosed = false;
            }
            else if (!doorClosed && (doorPivot.rotation.eulerAngles.y == 90f || doorPivot.rotation.eulerAngles.y == 270f))
            {
                if (gameObject.CompareTag("LeftDoorTrigger"))
                {
                    door.Play("DoorCloseLeft");
                }
                if (gameObject.CompareTag("RightDoorTrigger"))
                {
                    door.Play("DoorCloseRight");
                }

                doorClosed = true;
            }
        }
    }
}
