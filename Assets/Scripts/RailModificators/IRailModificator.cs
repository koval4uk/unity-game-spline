using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRailModificator
{
    void Play(StickmanEvents stickmanEvents);
    void Stop(StickmanEvents stickmanEvents);
}
