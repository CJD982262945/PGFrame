using UnityEngine;
using System;
using System.Collections;

namespace WS1
{

	using PGFrame;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using PogoTools;

	public class FBController : FBControllerBase<FBController>
	{
		public FBController ()
		{
		}
		
		
		/*  */
		public override void FBTestCMD (FBViewModel viewModel)
		{
			base.FBTestCMD (viewModel);
		}
	}

}