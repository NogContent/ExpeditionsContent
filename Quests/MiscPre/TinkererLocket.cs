﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Expeditions144;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Quests.MiscPre
{
	class TinkererLocket : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Sweet Something";
			SetNPCHead(NPCID.GoblinTinkerer);
			expedition.difficulty = 1;
			expedition.ctgCollect = true;
		}
		public override void AddItemsOnLoad()
		{
			AddDeliverable(ModContent.ItemType<Items.QuestItems.HeartLocket>(), 1);

			AddRewardItem(ItemID.Radar, 1);
		}
		public override string Description(bool complete)
		{
			return "I wonder if you would be willing to trade that locket with me for something? I'm... uh... looking to impress someone, and I thought it'd make a nice present. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			// Makes no sense to display this without the mechanic present now would it?
			if (NPC.FindFirstNPC(NPCID.Mechanic) == -1) return false;

			return API.InInventory[ModContent.ItemType<Items.QuestItems.HeartLocket>()];
		}
	}
}
