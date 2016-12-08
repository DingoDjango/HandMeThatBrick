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
			UpdateDefs();
		}

		public override void SettingsChanged()
		{
			UpdateDefs();
		}

		private void UpdateDefs()
		{
			var haulersConstructionToggle = Settings.GetHandle<bool>("HaulersHelpConstruct", "setting_haulersConstructionToggle_label".Translate(), "setting_haulersConstructionToggle_desc".Translate(), true);
			HMTB_DefOf.HaulDeliverResourcesToFrames.scanThings = haulersConstructionToggle.Value;
			HMTB_DefOf.HaulDeliverResourcesToBlueprints.scanThings = haulersConstructionToggle.Value;
		}
	}
}