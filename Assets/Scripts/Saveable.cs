using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Saveable 
{
    void Save(ref GameData gameData);
    void Load(GameData gameData);
}
