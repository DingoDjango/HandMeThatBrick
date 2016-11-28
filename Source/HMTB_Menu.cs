using HugsLib;

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
			var toggle = Settings.GetHandle<bool>("HaulersHelpConstruct", "Use haulers for construction", "Any colonist set to hauling will also deliver materials to construction jobs.", true);
			HMTB_DefOf.HaulDeliverResourcesToFrames.scanThings = toggle.Value;
			HMTB_DefOf.HaulDeliverResourcesToBlueprints.scanThings = toggle.Value;
		}
	}
}