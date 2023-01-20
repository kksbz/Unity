using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public void PlayerDie()
    {
        gameObject.SetActive(false);
    }
}
