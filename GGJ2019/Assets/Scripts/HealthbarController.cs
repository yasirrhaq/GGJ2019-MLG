using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour {
    public PlayerController playerController;
    public Sprite[] faces;

    public Image expression;

    private void Update()
    {
        if (playerController.health > 60)
        {
            expression.sprite = faces[0];
        } else if (playerController.health <= 60 && playerController.health > 10)
        {
            expression.sprite = faces[1];
        } else if (playerController.health <= 10)
        {
            expression.sprite = faces[2];
        }
    }

}
