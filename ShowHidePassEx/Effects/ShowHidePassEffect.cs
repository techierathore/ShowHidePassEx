using System;
using Xamarin.Forms;

namespace ShowHidePassEx.Effects
{
	public class ShowHidePassEffect : RoutingEffect
	{
        public string EntryText { get; set; }
		public ShowHidePassEffect() : base("Xamarin.ShowHidePassEffect"){}
	}

}
