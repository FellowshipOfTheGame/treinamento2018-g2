using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class BrokenIce : Tile {

	#if UNITY_EDITOR
// The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/Special Tiles/BrokenIceTile")]
    public static void CreateIceTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Tile", "New Tile", "Asset", "Save Tile", "Assets");
        if (path == "")
            return;
    	AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BrokenIce>(),path);
    }
#endif

}
