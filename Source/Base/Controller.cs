using HugsLib;
using HugsLib.Settings;
using Verse;

namespace HMTB
{
	public class Controller : ModBase
	{
		public static SettingHandle<bool> EnableMod;

		public static SettingHandle<OpportunityDistance> OpportunisticMode;

		public override void DefsLoaded()
		{
			base.DefsLoaded();

			EnableMod = this.Settings.GetHandle("EnableMod", "HMTB_EnableMod".Translate(), "HMTB_Tooltip_EnableMod".Translate(), true);
			OpportunisticMode = this.Settings.GetHandle("OpportunisticMode", "HMTB_OpportunisticMode".Translate(), "HMTB_Tooltip_OpportunisticMode".Translate(), OpportunityDistance.HMTB_Unrestricted, null, "");
		}

		public override string ModIdentifier => "HandMeThatBrick";
	}
}
