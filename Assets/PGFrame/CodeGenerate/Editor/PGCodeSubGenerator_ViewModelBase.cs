﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

public class PGCodeSubGenerator_ViewModelBase: IPGCodeSubGenerator
{
	public PGCodeSubGenerator_ViewModelBase ()
	{
	}

	public PGCodeSubGenerator_ViewModelBase (string templateFileName)
	{
		templateFileInfo = new FileInfo (templateFileName);
	}

	FileInfo templateFileInfo;

	#region IPGCodeSubGenerator implementation

	public bool CanGenerate (JObject jo)
	{
		string workspaceName = jo ["Workspace"].Value<string> ();
		string elementName = jo ["Common"] ["Name"].Value<string> ();
		string targetPath = Path.Combine (Application.dataPath, "_Main/" + workspaceName + "/_Scripts/ViewModel/_Base");
		string file = Path.Combine (targetPath, string.Format ("{0}ViewModelBase.cs", elementName));
		return !File.Exists (file);
	}

	public void GenerateCode (JObject jo, IList<string> filesGenerated)
	{
		string workspaceName = jo ["Workspace"].Value<string> ();
		string elementName = jo ["Common"] ["Name"].Value<string> ();
		string targetPath = Path.Combine (Application.dataPath, "_Main/" + workspaceName + "/_Scripts/ViewModel/_Base");
		string code = File.ReadAllText (templateFileInfo.FullName);
		code = code.Replace ("__XXX__", elementName);
		string file = Path.Combine (targetPath, string.Format ("{0}ViewModelBase.cs", elementName));
		File.WriteAllText (file, code);
		filesGenerated.Add (file);
	}

	#endregion
}
