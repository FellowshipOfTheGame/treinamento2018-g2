using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class BreakableIce : Tile {

	#if UNITY_EDITOR
// The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/Special Tiles/BreakableIceTile")]
    public static void CreateIceTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Ice Tile", "New Ice Tile", "Asset", "Save Ice Tile", "Assets");
        if (path == "")
            return;
    	AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BreakableIce>(),path);
    }
#endif
}
