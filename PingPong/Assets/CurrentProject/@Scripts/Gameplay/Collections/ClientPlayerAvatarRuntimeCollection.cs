using System;
using PM.PingPong.General;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
    /// <summary>
    /// A runtime list of <see cref="PersistentPlayer"/> objects that is populated both on clients and server.
    /// </summary>
    //[CreateAssetMenu]
    public class ClientPlayerAvatarRuntimeCollection : RuntimeCollection<ClientPlayerAvatar>
    {
    }
}
