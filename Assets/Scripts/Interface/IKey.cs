using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKey
{
    void OpenDoor(bool isKey);

    void GardeningScissors(bool isKey);

    void Green(bool isKey);

    void Hidden(bool isKey);
}
