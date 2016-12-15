using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UniRx;

public class BulletViewBase : ViewBase , IBulletView
{
	public BulletViewModel VM;

	public BulletViewModel Bullet {
		get {
			return VM;
		}
	}

	public override ViewModelBase GetViewModel ()
	{
		return VM;
	}

	public override void Initialize (ViewModelBase viewModel)
	{
		if (viewModel != null) {
			VM = (BulletViewModel)viewModel;
			VM.AddHostView (ViewBaseKey, this);
		} else {
			if (AutoCreateViewModel && VM == null) {
				CreateViewModel ();
			}
		}

		base.Initialize (VM);
	}

	public override void CreateViewModel ()
	{
		if (UseEmptyViewModel || string.IsNullOrEmpty (ViewModelInitValueJson)) {
			VM = new BulletViewModel ();
		} else {
			VM = JsonConvert.DeserializeObject<BulletViewModel> (ViewModelInitValueJson);
			ViewModelPropertyRef ();
		}
		
		VM.AddHostView (ViewBaseKey, this);
	}

	public void ViewModelPropertyRef ()
	{
		
	}

	public override void Bind ()
	{
		base.Bind ();
		
	}

	public override void AfterBind ()
	{
		base.AfterBind ();
	}

	

	
}
