using Project;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class DropPickUp : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentWeapon;
    bool canPickUp = false;
    ItemData [] Items = ProjectContext.Instance.DataService.Items;
    
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
            var sword = new InventoryItem(Items[0]);
            currentWeapon = hit.transform.gameObject;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
            currentWeapon.GetComponent<Collider>().isTrigger = true;
            currentWeapon.transform.parent = transform;
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localEulerAngles = new Vector3(20f, 80f, 0f);
            ProjectContext.Instance.InventoryService.AddItem(sword);
           
            Debug.Log(ProjectContext.Instance == null ? "ProjectContext.Instance is null" : "ProjectContext.Instance is not null");
            Debug.Log(ProjectContext.Instance?.InventoryService == null ? "InventoryService is null" : "InventoryService is not null");
            if (sword == null)
            {
                Debug.LogError("Sword item is null");
            }
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
