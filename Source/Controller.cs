using UnityEngine;
using Verse;

namespace HMTB
{
	public class Controller : Mod
	{
		private string labelEnableHMTB;
		private string descEnableHMTB;

		public Controller(ModContentPack content) : base(content)
		{
			GetSettings<Settings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			//Initialising strings here as the Mod class is loaded before language data
			if (this.labelEnableHMTB == default(string))
			{
				labelEnableHMTB = "HMTB_EnableHMTB_Label".Translate();
				descEnableHMTB = "HMTB_EnableHMTB_Desc".Translate();
			}

			Listing_Standard list = new Listing_Standard
			{
				ColumnWidth = inRect.width
			};

			list.Begin(inRect);

			list.Gap(20f);

			list.CheckboxLabeled(this.labelEnableHMTB, ref Settings.EnableHMTB, this.descEnableHMTB);

			list.End();
		}

		public override string SettingsCategory()
		{
			return "Hand Me That Brick";
		}
	}
}
