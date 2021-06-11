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
    public Color joinedColor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        setObjectsColor(defaultColor);
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("Distance from player: " + playerDistance);

        if (!joinedWithPlayer && playerDistance < playerController.joinDistance) {
            joinedWithPlayer = true;
            playerController.linkedObjects.Add(gameObject);

            setObjectsColor(Color.green);
        }

        if (joinedWithPlayer && playerDistance > playerController.joinDistance) {
            joinedWithPlayer = false;
            playerController.linkedObjects.Remove(gameObject);

            setObjectsColor(defaultColor);
        }
    }

    private void setObjectsColor(Color color) {
        Renderer[] thisRenderers = GetComponentsInChildren<Renderer>(); // TODO optimization
        foreach (Renderer renderer in thisRenderers) {
            renderer.material.color = color;
        }
    }
}
