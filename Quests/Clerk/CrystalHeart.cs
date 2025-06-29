﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Clerk
{
	class CrystalHeart : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Hearty Quest";
			SetNPCHead(ExpeditionC144.NPCIDClerk);
			expedition.difficulty = 2;
			expedition.ctgExplore = true;
			expedition.partyShare = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ItemID.LifeCrystal, 2);

			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
		}
		public override string Description(bool complete)
		{
			if (complete) return "So I was messing with those crystal hearts, and I seem to have made some kind of... compass? Either way it looks it responds to nearby hearts, so if you're still looking for more of those crystals, be sure to check in out in the store!";
			return "I want to experiment with these crystal hearts, apparently they do something that toughens your endurance? Maybe even make you look younger! Just think of the possibilities! ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			// Only until player has max health
			return API.FindExpedition<Core.ACUnderground>(mod).completed;
		}

		public override void PostCompleteExpedition()
		{
			WayfarerWeapons.ShowItemUnlock("Heart Compass", expedition.difficulty);
		}
	}
}
