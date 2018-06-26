using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class FrozenGround : Tile {

	#if UNITY_EDITOR
// The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/Special Tiles/FrozenTile")]
    public static void CreateFrozenTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Tile", "New Tile", "Asset", "Save Tile", "Assets");
        if (path == "")
            return;
    	AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<FrozenGround>(),path);
    }
#endif
}
