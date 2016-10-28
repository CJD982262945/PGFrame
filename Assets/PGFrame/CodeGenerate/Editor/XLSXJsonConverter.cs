﻿using UnityEngine;
using System.Collections;
using System.Data;
using Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PogoTools;

public class XLSXJsonConverter
{
	public static readonly string lt = "PGFrame.XLSXJsonConverter";
	public static readonly Color lc = new Color32 (0, 162, 255, 255);
	public static readonly Color lc_r = new Color32 (255, 162, 162, 255);

	public XLSXElement Element;

	public void SetElement (XLSXElement element)
	{
		this.Element = element;
		this.Table = null;
	}

	public DataTable Table;

	public void SetDataTable (XLSXElement element, DataTable table)
	{
		this.Element = element;
		this.Table = table;
	}

	public void Convert ()
	{
		JArray ja = new JArray ();
		if (Table != null) {
			JObject jo = TableConvert (Table);
			PRDebug.TagLog (lt, lc, JsonConvert.SerializeObject (jo, Formatting.Indented));
		}
	}

	public JObject TableConvert (DataTable dt)
	{
		cidx cidx = GetCIDX (dt);

		JObject jo = new JObject ();

		for (int i = 1; i < 999; i++) {
			DataRow row = dt.Rows [i];
		}

		return null;
	}

	public class cidx
	{
		public int StartRowIdx;
		public int StartColIdx;

		public int ClassType;
		public int Name;
		public int Type;
		public int Description;
		public int ParamName;
		public int ParamType;
		public int ParamDescription;
		public int Add;
		public int Remove;
		public int Replace;
	}

	public cidx GetCIDX (DataTable dt)
	{
		cidx cidx = new cidx ();
		cidx.StartRowIdx = -1;
		cidx.StartColIdx = -1;

		for (int ri = 0; ri < 99; ri++) {
			for (int ci = 0; ci < 9; ci++) {
				string c0 = dt.Rows [ri] [ci].ToString ();
				if (c0 == "#Start") {
					cidx.StartRowIdx = ri;
					cidx.StartColIdx = ci;
				}
				if (cidx.StartRowIdx != -1)
					break;
			}
			if (cidx.StartColIdx != -1)
				break;
		}

		DataRow r = dt.Rows [cidx.StartRowIdx];

		for (int i = cidx.StartColIdx; i < cidx.StartColIdx + 99; i++) {
			var cell = r [i].ToString ();

			if (string.IsNullOrEmpty (cell))
				continue;
			if (cell == "#End")
				break;

			switch (cell) {
			case "#Start":
				cidx.ClassType = i;
				break;
			case "Name":
				cidx.Name = i;
				break;
			case "Type":
				cidx.Type = i;
				break;
			case "Description":
				cidx.Description = i;
				break;
			case "ParamName":
				cidx.ParamName = i;
				break;
			case "ParamType":
				cidx.ParamType = i;
				break;
			case "ParamDescription":
				cidx.ParamDescription = i;
				break;
			case "Add":
				cidx.Add = i;
				break;
			case "Remove":
				cidx.Remove = i;
				break;
			case "Replace":
				cidx.Replace = i;
				break;
			default:
				break;
			}
		}
		
		return cidx;
	}
}
