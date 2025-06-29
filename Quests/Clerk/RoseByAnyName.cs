﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;
using System.Collections.Generic;

namespace ExpeditionsContent144.Quests.Clerk
{
	class RoseByAnyName : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "A Rose by Any Other Name";
			SetNPCHead(ExpeditionC144.NPCIDClerk);
			expedition.difficulty = 3;
			expedition.ctgCollect = true;
			expedition.partyShare = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ItemID.NaturesGift, 1);

			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
		}
		public override string Description(bool complete)
		{
			if (complete) return "Wow, this flower is positively flowing with magic! I've sent it off for further study; imagine how popular it might be with botanists and magicians. Speaking of magicians, I just got in a magic staff weapon, so feel free take a look in store. ";
			return "Apparently, a rare flower known as 'nature's gift' blooms in the jungle. Why does it warrant attention, you may ask? Well, that's for you to find out! After all, if something's rare it's probably worth looking for, right? ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!cond1) cond1 = NPC.FindFirstNPC(NPCID.Demolitionist) >= 0 && API.TimeWitchingHour;
			return cond1;
		}

		public override void PostCompleteExpedition()
		{
			WayfarerWeapons.ShowItemUnlock("Wayfarer's Cane", expedition.difficulty);
		}
	}
}
