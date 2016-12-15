using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WS1 {

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using UniRx;

	public class PTestViewBase : ViewBase , IPTestView
	{
		public PTestViewModel VM;

		public PTestViewModel PTest {
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
				VM = (PTestViewModel)viewModel;
				VM.AddHostView (ViewModelBase.DefaultViewBaseKey, this);
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
				VM = new PTestViewModel ();
			} else {
				VM = JsonConvert.DeserializeObject<PTestViewModel> (ViewModelInitValueJson);
				ViewModelPropertyRef ();
			}
			
			VM.AddHostView (ViewModelBase.DefaultViewBaseKey, this);
		}

		public void ViewModelPropertyRef ()
		{
			
		if (_CurrentFBView.GetViewModel () == null) {
			_CurrentFBView.CreateViewModel ();
		}
		VM.CurrentFB = _CurrentFBView.GetViewModel () as FBViewModel;
		}

		public override void Bind ()
		{
			base.Bind ();
			
		VM.RP_DefaultProperty1.Subscribe (OnChanged_DefaultProperty1);
		VM.RP_DefaultProperty2.Subscribe (OnChanged_DefaultProperty2);
		VM.RP_DefaultProperty3.Subscribe (OnChanged_DefaultProperty3);
		VM.RP_DefaultProperty4.Subscribe (OnChanged_DefaultProperty4);
		VM.DefaultCollection1.ObserveAdd ().Subscribe (OnAdd_DefaultCollection1);
		VM.DefaultCollection1.ObserveRemove ().Subscribe (OnRemove_DefaultCollection1);
		VM.DefaultCollection2.ObserveAdd ().Subscribe (OnAdd_DefaultCollection2);
		VM.DefaultCollection2.ObserveRemove ().Subscribe (OnRemove_DefaultCollection2);
		VM.DefaultDictionary1.ObserveAdd ().Subscribe (OnAdd_DefaultDictionary1);
		VM.DefaultDictionary1.ObserveRemove ().Subscribe (OnRemove_DefaultDictionary1);
		VM.DefaultDictionary2.ObserveAdd ().Subscribe (OnAdd_DefaultDictionary2);
		VM.DefaultDictionary2.ObserveRemove ().Subscribe (OnRemove_DefaultDictionary2);
		VM.RC_DefaultCommand1.Subscribe<DefaultCommand1Command> (OnExecuted_DefaultCommand1);
		VM.RC_DefaultCommand2.Subscribe (OnExecuted_DefaultCommand2);
		VM.RC_DefaultCommand3.Subscribe (OnExecuted_DefaultCommand3);
		VM.RC_DefaultCommand4.Subscribe (OnExecuted_DefaultCommand4);
		VM.RC_DefaultCommand5.Subscribe (OnExecuted_DefaultCommand5);
		VM.RC_DefaultCommand6.Subscribe (OnExecuted_DefaultCommand6);
		VM.RC_DefaultCommand7.Subscribe (OnExecuted_DefaultCommand7);
		VM.RC_DefaultCommand8.Subscribe<DefaultCommand8Command> (OnExecuted_DefaultCommand8);
		VM.RC_DefaultCommand9.Subscribe (OnExecuted_DefaultCommand9);
		VM.RC_DefaultCommand10.Subscribe (OnExecuted_DefaultCommand10);
		VM.RC_DefaultCommand11.Subscribe (OnExecuted_DefaultCommand11);
		VM.RC_DefaultCommand12.Subscribe (OnExecuted_DefaultCommand12);
		VM.RC_DefaultCommand13.Subscribe (OnExecuted_DefaultCommand13);
		VM.RC_DefaultCommand14.Subscribe (OnExecuted_DefaultCommand14);
		VM.RC_DefaultCommand15.Subscribe (OnExecuted_DefaultCommand15);
		VM.RC_DefaultCommand16.Subscribe (OnExecuted_DefaultCommand16);
		VM.RC_DefaultCommand17.Subscribe (OnExecuted_DefaultCommand17);
		VM.RC_DefaultCommand18.Subscribe (OnExecuted_DefaultCommand18);
		VM.RC_DefaultCommand19.Subscribe (OnExecuted_DefaultCommand19);
		VM.RC_DefaultCommand20.Subscribe (OnExecuted_DefaultCommand20);
		}

		public override void AfterBind ()
		{
			base.AfterBind ();
		}

		

		public virtual void OnChanged_DefaultProperty1 (string value)
		{
		}

		public virtual void OnChanged_DefaultProperty2 (string value)
		{
		}

		public virtual void OnChanged_DefaultProperty3 (int value)
		{
		}

		public virtual void OnChanged_DefaultProperty4 (float value)
		{
		}

		public virtual void OnAdd_DefaultCollection1 (CollectionAddEvent<string> e)
		{
		}

		public virtual void OnRemove_DefaultCollection1 (CollectionRemoveEvent<string> e)
		{
		}

		public virtual void OnAdd_DefaultCollection2 (CollectionAddEvent<int> e)
		{
		}

		public virtual void OnRemove_DefaultCollection2 (CollectionRemoveEvent<int> e)
		{
		}

	public virtual void OnAdd_DefaultDictionary1 (DictionaryAddEvent<string, string> e)
	{
	}

	public virtual void OnRemove_DefaultDictionary1 (DictionaryRemoveEvent<string, string> e)
	{
	}

	public virtual void OnAdd_DefaultDictionary2 (DictionaryAddEvent<int, string> e)
	{
	}

	public virtual void OnRemove_DefaultDictionary2 (DictionaryRemoveEvent<int, string> e)
	{
	}

		public virtual void OnExecuted_DefaultCommand1 (DefaultCommand1Command command)
		{
		}

		public virtual void OnExecuted_DefaultCommand2 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand3 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand4 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand5 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand6 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand7 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand8 (DefaultCommand8Command command)
		{
		}

		public virtual void OnExecuted_DefaultCommand9 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand10 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand11 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand12 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand13 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand14 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand15 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand16 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand17 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand18 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand19 (Unit unit)
		{
		}

		public virtual void OnExecuted_DefaultCommand20 (Unit unit)
		{
		}

		
	
	[SerializeField, HideInInspector]
	public ViewBase _CurrentFBView;
	public IFBView CurrentFBView {
		get {
			return (IFBView)_CurrentFBView;
		}
		set {
			_CurrentFBView = (ViewBase)value;
		}
	}
	}

}