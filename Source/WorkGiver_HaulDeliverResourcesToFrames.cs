using RimWorld;
using Verse;

namespace HandMeThatBrick
{
	public class WorkGiver_HaulDeliverResourcesToFrames : WorkGiver_ConstructDeliverResourcesToFrames
	{
		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Frame frame = t as Frame;
			return base.HasJobOnThing(pawn, t) && !frame.MaterialsNeeded().NullOrEmpty() && Settings.EnableHMTB;
		}
	}
}