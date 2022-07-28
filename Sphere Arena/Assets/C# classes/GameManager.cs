using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip weaponNoise; //an audioclip variable to assign to both players on awake
    public static bool gameOn = true; //while true, scripts that use while loops will do things as long as the match isn't over
    [SerializeField] float weaponStrength; //the stregth of all the player weapons in the scene

    public static GameObject host; //The host is the player that started the room
    public static GameObject guest; //The guest is the second player in the room

    private void Awake()
    {
        PlayerWeapon.weaponNoise = weaponNoise;
        PlayerWeapon.pushStrength = weaponStrength;
    }
}
