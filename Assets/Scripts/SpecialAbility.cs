using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;

    public Button ability;

    private WaitForSecondsRealtime oneSec = new WaitForSecondsRealtime(1);

    private string fireText = "Fire!";
    private int abilityTimer = 5;
    private int abilityCurrentTimer;
    private IEnumerator coroutine;
    private float firePause = 5f;

    private bool weaponReady = true;

    private PlayerController playerController;

    public void Start()
    {
        playerController = shotSpawn.GetComponentInParent<PlayerController>();
    }

    public void OnSpecialAbility()
    {
        if (weaponReady)
        {
            if (playerController != null)
            {
                playerController.SetNextFire(firePause);
            }
            coroutine = SetAbilityText(ability.GetComponentInChildren<Text>());
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator SetAbilityText(Text t)
    {
        weaponReady = false;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        abilityCurrentTimer = abilityTimer;
        while (abilityCurrentTimer > 0)
        {
            t.text = abilityCurrentTimer.ToString();
            abilityCurrentTimer--;
            yield return oneSec;
        }
        abilityCurrentTimer = abilityTimer;
        t.text = fireText;
        weaponReady = true;
    }

}
