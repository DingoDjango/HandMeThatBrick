using RimWorld;
using Verse;
using Verse.AI;

namespace HMTB
{
	public static class Utilities
	{
		public static bool AllowedHaulDistance(Pawn pawn, Thing t)
		{
			OpportunityDistance distance = Controller.OpportunisticMode.Value;

			if (distance == OpportunityDistance.HMTB_Unrestricted)
			{
				return true;
			}

			float maxSearchDistance;

			switch (distance)
			{
				case OpportunityDistance.HMTB_Close:
					maxSearchDistance = 15f; //Close
					break;
				case OpportunityDistance.HMTB_Medium:
					maxSearchDistance = 45f; //Medium
					break;
				default:
					maxSearchDistance = 100f; //Long
					break;
			}

			return t.Position.DistanceTo(pawn.Position) <= maxSearchDistance;
		}

		/* RimWorld.GenConstruct.CanConstruct
		 * Tweaked vanilla code to disregard pawn skill */
		public static bool CanDeliverResources(Thing t, Pawn p, Thing firstBlocking, bool forced = false)
		{
			if (firstBlocking != null)
			{
				return false;
			}

			LocalTargetInfo target = t;

			Danger maxDanger = !forced ? p.NormalMaxDanger() : Danger.Deadly;

			if (!p.CanReserveAndReach(target, PathEndMode.Touch, maxDanger, 1, -1, null, forced))
			{
				return false;
			}

			if (t.IsBurning())
			{
				return false;
			}

			return true;
		}
	}
}
