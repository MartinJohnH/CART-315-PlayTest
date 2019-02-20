using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout  {

	[System.Serializable]
	public struct rowData{
		public string[]row;
	}

	public rowData[] rows = new rowData[(int)Spawn.gridY];
}
