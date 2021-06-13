using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinedObjectController : MonoBehaviour {

    public Material defaultMaterial;
    public Material joinedMaterial;
    public GameObject[] renderWhenJoined;

    private bool joinedWithPlayer = false;
    private GameObject player;
    private PlayerController playerController;
    private Renderer[] thisRenderers;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (player) {
            playerController = player.GetComponent<PlayerController>();
        }


        setObjectsMaterial(defaultMaterial);
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

            setObjectsMaterial(joinedMaterial);
            changeRenderWhenJoined(true);
        }

        if (joinedWithPlayer && playerDistance > joinDistance) {
            joinedWithPlayer = false;
            playerController.linkedObjects.Remove(gameObject);

            setObjectsMaterial(defaultMaterial);
            changeRenderWhenJoined(false);
        }
    }

    private void setObjectsMaterial(Material material) {
        Renderer[] thisRenderers = GetComponentsInChildren<Renderer>(); // TODO optimization
        foreach (Renderer renderer in thisRenderers) {
            string rendererTag = renderer.gameObject.tag;
            if (!rendererTag.Equals("Range") && !rendererTag.Equals("Fuel")) {
                renderer.material = material;
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
