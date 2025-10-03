using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="GridData")]
public class GridDataSO : ScriptableObject
{
  public List<GridData> gridDatas;
}

[Serializable]
public class GridData
{
    public int gridSize;
    public Vector3 scal;
    public Vector3 pos;
}