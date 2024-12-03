using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InteractionManagerScript : MonoBehaviour
{
    public GameObject theCamera;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject activeList;
    public Material nodeMat;
    
    void Update()
    {
        Raycasting();
    }

    private void Raycasting()
    {
        RaycastHit hit;

        if (Physics.Raycast(leftController.transform.position, leftController.transform.forward, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.gameObject.SendMessage("Highlight");

            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                // Changes skybox to node's respective material
                Material theStoredMaterial = hit.collider.gameObject.GetComponent<NodeLoadingScript>().myMaterial;
                RenderSettings.skybox = theStoredMaterial;

                // Loads new list of nodes for respective skybox
                GameObject theNodeList = hit.collider.gameObject.GetComponent<NodeLoadingScript>().myNodeList;
                activeList.SetActive(false);
                theNodeList.SetActive(true);
                activeList = theNodeList;
            }
        }

        if (Physics.Raycast(rightController.transform.position, rightController.transform.forward, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.gameObject.SendMessage("Highlight");

            if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                // Changes skybox to node's respective material
                Material theStoredMaterial = hit.collider.gameObject.GetComponent<NodeLoadingScript>().myMaterial;
                RenderSettings.skybox = theStoredMaterial;

                // Loads new list of nodes for respective skybox
                GameObject theNodeList = hit.collider.gameObject.GetComponent<NodeLoadingScript>().myNodeList;
                activeList.SetActive(false);
                theNodeList.SetActive(true);
                activeList = theNodeList;
            }
        }
    }

    private void UpdateSkybox(RaycastHit hit)
    {
        // Changes skybox to node's respective material
        Material theStoredMaterial = hit.collider.gameObject.GetComponent<NodeLoadingScript>().myMaterial;
        RenderSettings.skybox = theStoredMaterial;

        // Loads new list of nodes for respective skybox
        GameObject theNodeList = hit.collider.gameObject.GetComponent<NodeLoadingScript>().myNodeList;
        activeList.SetActive(false);
        theNodeList.SetActive(true);
        activeList = theNodeList;
    }
}