﻿using UnityEngine;

public static class Utils
{
    private const string PLAYER_LAYER = "Player";
    private const string KILLVOLUME_LAYER = "KillVolume";
    private const string BULLET_LAYER = "Bullet";

    public static int PlayerLayer { get => NameToLayer(PLAYER_LAYER); }
    public static int KillVolumeLayer { get => NameToLayer(KILLVOLUME_LAYER); }
    public static int BulletLayer { get => NameToLayer(BULLET_LAYER); }

    private static int NameToLayer(string layerName) => LayerMask.NameToLayer(layerName);
}