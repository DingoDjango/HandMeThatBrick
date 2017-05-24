using UnityEngine;
using Verse;

namespace HandMeThatBrick
{
	public class Controller : Mod
	{
		public Controller(ModContentPack content) : base(content)
		{
			GetSettings<Settings>();
		}

		public override void WriteSettings()
		{
			base.WriteSettings();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			Listing_Standard list = new Listing_Standard();
			list.ColumnWidth = inRect.width;
			list.Begin(inRect);
			list.Gap();
			list.CheckboxLabeled("HMTB_setting_haulersConstructionToggle_label".Translate(), ref Settings.EnableHMTB, "HMTB_setting_haulersConstructionToggle_desc".Translate());
			list.End();
		}

		public override string SettingsCategory()
		{
			return "HMTB".Translate();
		}
	}
}