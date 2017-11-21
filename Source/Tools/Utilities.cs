using Verse;

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
	}
}
