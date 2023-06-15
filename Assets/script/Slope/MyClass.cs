using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int value;
    public string str;
    public data2 d2;
    // 他のデータプロパティを追加することもできます
}

[System.Serializable]
public class data2
{
    public float speed;
    public Vector2 vec;
}

[System.Serializable]
public class MyClass : MonoBehaviour
{
    public List<int> ids = new List<int>();
    public List<Data> dataList = new List<Data>();

}

[CustomEditor(typeof(MyClass))]
public class MyClassEditor : Editor
{
    private SerializedProperty idsProperty;
    private SerializedProperty dataListProperty;
   
    private void OnEnable()
    {
        idsProperty = serializedObject.FindProperty("ids");
        dataListProperty = serializedObject.FindProperty("dataList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(idsProperty, true);
        EditorGUILayout.PropertyField(dataListProperty, true);

        serializedObject.ApplyModifiedProperties();
    }
}
