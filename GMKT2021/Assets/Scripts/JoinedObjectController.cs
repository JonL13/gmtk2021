using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinedObjectController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private Renderer[] thisRenderers;
    private bool joinedWithPlayer = false;

    public Color defaultColor;
    public GameObject[] renderWhenJoined;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (player) {
            playerController = player.GetComponent<PlayerController>();
        }

        setObjectsColor(defaultColor);
        changeRenderWhenJoined(false);
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = 1000f;
        if (player != null) {
            playerDistance = Vector3.Distance(player.transform.position, transform.position);
        }

        float joinDistance = 0;
        if(playerController != null) {
            joinDistance = playerController.joinDistance;
        }

        if (!joinedWithPlayer && playerDistance < joinDistance) {
            joinedWithPlayer = true;
            playerController.linkedObjects.Add(gameObject);

            setObjectsColor(Color.green);
            changeRenderWhenJoined(true);
        }

        if (joinedWithPlayer && playerDistance > joinDistance) {
            joinedWithPlayer = false;
            playerController.linkedObjects.Remove(gameObject);

            setObjectsColor(defaultColor);
            changeRenderWhenJoined(false);
        }
    }

    private void setObjectsColor(Color color) {
        Renderer[] thisRenderers = GetComponentsInChildren<Renderer>(); // TODO optimization
        foreach (Renderer renderer in thisRenderers) {
            if (!renderer.gameObject.name.Equals("RangeCylinder")) {
                renderer.material.color = color;
            }
        }
    }

    private void changeRenderWhenJoined(bool isRendering) {
        foreach (GameObject objectToRender in renderWhenJoined) {
            Renderer renderer = objectToRender.GetComponent<Renderer>();
            renderer.enabled = isRendering;
        }
    }
}
