using Verse;

namespace HandMeThatBrick
{
	public class Settings : ModSettings
	{
		internal static bool EnableHMTB = true;

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref EnableHMTB, "PauseHMTB", true);
		}
	}
}