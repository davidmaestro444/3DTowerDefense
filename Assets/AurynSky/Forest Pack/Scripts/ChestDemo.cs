namespace AurynSky.ForestPack
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    public Animator chestAnim;

	void Awake ()
    {
        chestAnim = GetComponent<Animator>();
        StartCoroutine(OpenCloseChest());
	}

    IEnumerator OpenCloseChest()
    {
        chestAnim.SetTrigger("open");
        yield return new WaitForSeconds(2);
        chestAnim.SetTrigger("close");
        yield return new WaitForSeconds(2);
        StartCoroutine(OpenCloseChest());
    }
}
}