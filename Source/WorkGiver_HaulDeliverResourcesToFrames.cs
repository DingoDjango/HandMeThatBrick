using RimWorld;
using Verse;

namespace HMTB
{
	public class WorkGiver_HaulDeliverResourcesToFrames : WorkGiver_ConstructDeliverResourcesToFrames
	{
		public override bool ShouldSkip(Pawn pawn)
		{
			return !Settings.EnableHMTB;
		}

		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Frame frame = t as Frame;

			return !frame.MaterialsNeeded().NullOrEmpty() && base.HasJobOnThing(pawn, t, forced);
		}
	}
}
