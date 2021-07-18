using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GripperControl : MonoBehaviour
{
    private GameObject openGripperButton;
    private GameObject closeGripperButton;
    private GameObject squeezeBottleButton;
    private RosSharp.RosBridgeClient.GripperControlSub gripperControlSub;
    public List<GameObject> spills;
    public bool gripperClosed = false;
    public GameObject robotGripper;
    public GameObject gelBottle;
    public GameObject sponge;
    public GameObject spillPrefab;
    public GameObject pickedObject;
    public GameObject bottleCap;
    private bool removeSpill = false;
    public ParticleSystem gel;
    private RosSharp.RosBridgeClient.GripperPublisher gripperPublisher;

    private bool objectPicked = false;


    // Start is called before the first frame update
    void Start()
    {
        gripperControlSub = gameObject.GetComponent<RosSharp.RosBridgeClient.GripperControlSub>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedObject == sponge)
        {
            GameObject spillToRemove = null;
            foreach (GameObject spill in spills)
            {
                if ((Vector3.Distance(pickedObject.transform.position, spill.transform.position) < 0.1f))
                {
                    RaycastHit hit;
                    if (Physics.Raycast(spill.transform.position, spill.transform.up, out hit))
                    {
                        if (hit.transform.gameObject.name == "Sponge")
                        {
                            spillToRemove = spill;
                        }
                    }
                }
            }

            spills.Remove(spillToRemove);//.SetActive(false);
            DestroyImmediate(spillToRemove);

        }

        /*
        if (pickedObject == sponge && spill.active)
        {
            if ((Vector3.Distance(pickedObject.transform.position, spill.transform.position) < 0.1f))
            {
                RaycastHit hit;
                if (Physics.Raycast(spill.transform.position, spill.transform.up, out hit))
                {
                    if (hit.transform.gameObject.name == "Sponge") spill.SetActive(false);
                }
            }
        }*/
      
        /*
        if (raycastGel)
        {
            Vector3 fwd = pickedObject.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(pickedObject.transform.position, fwd * 50, Color.green);
        }*/


    }

    private void Awake()
    {
        openGripperButton = GameObject.Find("OpenGripperButton");
        openGripperButton.GetComponent<Button>().onClick.AddListener(OpenGripper);
        closeGripperButton = GameObject.Find("CloseGripperButton");
        closeGripperButton.GetComponent<Button>().onClick.AddListener(CloseGripper);
        squeezeBottleButton = GameObject.Find("SqueezeBottleButton");
        squeezeBottleButton.GetComponent<Button>().onClick.AddListener(SqueezeBottle);
        gripperPublisher = gameObject.GetComponent<RosSharp.RosBridgeClient.GripperPublisher>();
    }

    public void OpenGripper()
    {
        Debug.Log("Opening gripper");
        gripperPublisher.rpr = 0;
        //gripperPublisher.UpdateMessage();
        EmptyEventSystem();
        gripperClosed = false;
        objectPicked = false;

        if (pickedObject != null)
        {
            pickedObject.transform.SetParent(null, true);
            pickedObject.GetComponent<Collider>().attachedRigidbody.useGravity = true;
            pickedObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
            pickedObject = null;
        }
        gripperControlSub.isMessageReceived = false;
        
    }

    public void CloseGripper()
    {
        Debug.Log("Closing gripper");
        gripperPublisher.rpr = 150;
        //gripperPublisher.UpdateMessage();
        EmptyEventSystem();
        gripperClosed = true;

        if ((Vector3.Distance(robotGripper.transform.position, gelBottle.transform.position) < 0.1f) && !objectPicked)
        {
            pickedObject = gelBottle;
            AttachObject();
        }
        else if ((Vector3.Distance(robotGripper.transform.position, sponge.transform.position) < 0.1f) && !objectPicked)
        {
            pickedObject = sponge;
            AttachObject();
        }
        gripperControlSub.isMessageReceived = false;
    }

    public void SqueezeBottle()
    {
        //gripperPublisher.rpr = 160;
        //gripperPublisher.UpdateMessage();
        gel.Play();
        if (gripperClosed && (pickedObject == gelBottle))
        {
            StartCoroutine(GelRoutine());


        }
        gripperControlSub.isMessageReceived = false;
    }

    private void AttachObject()
    {
        pickedObject.transform.SetParent(robotGripper.transform, true);
        pickedObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        pickedObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
        pickedObject.GetComponent<Collider>().attachedRigidbody.isKinematic = true;

        /*if (pickedObject == gelBottle)
        {

            float currentZ = pickedObject.transform.localRotation.
            pickedObject.transform.localRotation =Quaternion.Euler(0.0f, 90.0f, -90.0f);
        }*/
        objectPicked = true;
    }

    public bool GetGripperStatus()
    {
        return gripperClosed;
    }

    private void EmptyEventSystem()
    {
        GameObject eventSystemObject = GameObject.Find("EventSystem");
        eventSystemObject.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    IEnumerator GelRoutine()
    {
        Debug.Log("Gel squirting");
        RaycastHit hit;

        if (Physics.Raycast(bottleCap.transform.position, bottleCap.transform.up, out hit))
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Found an object - point: " + hit.point);
            GameObject spill = Instantiate(spillPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            spill.transform.position = hit.point;
            //spill.transform.tag = "spill";
            //spills.Clear();
            spills.Add(spill);// = FindGameObjectsWithTag("spill");
        }
    }

    IEnumerator AttachObjectRoutine()
    {
        yield return new WaitForSeconds(1);
        pickedObject.transform.SetParent(robotGripper.transform, true);
        pickedObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        pickedObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
        pickedObject.GetComponent<Collider>().attachedRigidbody.isKinematic = true;

        /*if (pickedObject == gelBottle)
        {

            float currentZ = pickedObject.transform.localRotation.
            pickedObject.transform.localRotation =Quaternion.Euler(0.0f, 90.0f, -90.0f);
        }*/
        objectPicked = true;
    }
}
