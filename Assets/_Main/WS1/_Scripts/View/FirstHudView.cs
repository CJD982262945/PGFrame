using UnityEngine;
using System.Collections;
using UniRx;
using Newtonsoft.Json;
using PogoTools;
using UnityEngine.UI;

public class FirstHudView : FirstHudViewBase
{
	public override void Initialize (ViewModelBase viewModel)
	{
		base.Initialize (viewModel);
	}

	public override void Bind ()
	{
		base.Bind ();
		Debug.Log (string.Format ("FirstHudView in {0} Bind.", gameObject.name));
	}

	public override void AfterBind ()
	{
		base.AfterBind ();
		Debug.Log (string.Format ("FirstHudView in {0} AfterBind.", gameObject.name));
	}
}
