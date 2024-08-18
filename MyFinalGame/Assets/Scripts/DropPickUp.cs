using UnityEngine;

public class DropPickUp : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentWeapon;
    bool canPickUp = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

   void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag != "Weapon")
            return;

            if (canPickUp) Drop();

            currentWeapon = hit.transform.gameObject;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
            currentWeapon.GetComponent<Collider>().isTrigger = true;
            currentWeapon.transform.parent = transform;
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localEulerAngles = new Vector3(20f, 80f, 0f);
            canPickUp = true;
        }
    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Collider>().isTrigger = false;
        canPickUp = false;
        currentWeapon = null;
    }
}
