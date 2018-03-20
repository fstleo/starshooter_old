using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string eventType;
    public string soundName;
}

[Serializable]
public class SoundsSet  {

    public Sound[] sounds;
}
