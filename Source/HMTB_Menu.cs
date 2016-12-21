using HugsLib;
using Verse;

namespace HandMeThatBrick
{
	public class HMTB_Menu : ModBase
	{
		public override string ModIdentifier
		{
			get
			{
				return "HandMeThatBrick";
			}
		}

		public override void DefsLoaded()
		{
			HMTBDefs();
		}

		public override void SettingsChanged()
		{
			HMTBDefs();
		}

		private void HMTBDefs()
		{
			var haulersConstructionToggle = Settings.GetHandle<bool>("HaulersHelpConstruct", "HMTB_setting_haulersConstructionToggle_label".Translate(), "HMTB_setting_haulersConstructionToggle_desc".Translate(), true);
			HMTB_DefOf.HaulDeliverResourcesToFrames.scanThings = haulersConstructionToggle.Value;
			HMTB_DefOf.HaulDeliverResourcesToBlueprints.scanThings = haulersConstructionToggle.Value;
		}
	}
}