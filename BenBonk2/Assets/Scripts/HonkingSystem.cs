using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HonkingSystem : MonoBehaviour
{
    bool canHonk = true;
    public float cooldown = 10f;
    EnemyPlayer enemyPlayer;
    [Header("Images")]
    [SerializeField]
    Image uiSprite;

    void HonkUiChanger()
    {
        if (canHonk)
        {
            uiSprite.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            uiSprite.color = new Color(1f, 1f, 1f, .5f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        enemyPlayer = other.gameObject.GetComponent<EnemyPlayer>();
        if (other.CompareTag("enemy"))
        {
            if (Input.GetKey(KeyCode.Space) && (canHonk == true))
            {
                StartCoroutine(Timer());
                FindObjectOfType<audiomanager>().Play("PlayerHonking");
                Debug.Log("honked");

                //makeenemycar SpeedUp x2
                enemyPlayer.IncreaseSpeed();
            }
        }
    }
    IEnumerator Timer()
    {   
        canHonk = false;
        HonkUiChanger();
        yield return new WaitForSeconds(cooldown);
        canHonk = true;
        HonkUiChanger();
    }
}
