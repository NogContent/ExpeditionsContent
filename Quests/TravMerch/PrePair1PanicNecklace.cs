﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.TravMerch
{
	class PrePair1PanicNecklace : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Trading Panic Necklace";
			SetNPCHead(NPCID.TravellingMerchant);
			expedition.difficulty = 1;
			expedition.ctgCollect = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ItemID.GoldCoin);
			AddDeliverableAnyOf(new int[]{
				ItemID.BandofStarpower,
				ItemID.BallOHurt,
				ItemID.Vilethorn,
			}, 1);

			AddRewardItem(ItemID.PanicNecklace);
		}
		public override string Description(bool complete)
		{
			return "Having issues with fast foes? Or just finding yourself in harm's way. Fret not, this necklace is sure to get you out of a tight spot in a jiffy. ";
		}

		public override void OnNewDay(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			expedition.ResetProgress(true); //Reset after trade use
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			// Must have travelling merchant present
			if (NPC.FindFirstNPC(NPCID.TravellingMerchant) == -1) return false;

			//Won't offer unless item is held
			if (!API.InInventory[ItemID.BandofStarpower] &&
				!API.InInventory[ItemID.BallOHurt] &&
				!API.InInventory[ItemID.Vilethorn]
				) return false;

			return NPC.downedBoss1 && !WorldGen.crimson;
		}
	}
}
