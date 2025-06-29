﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Clerk
{
	class SOSWizard : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Search and Rescue: Wizard";
			SetNPCHead(ExpeditionC144.NPCIDClerk);
			expedition.difficulty = 4;
			expedition.ctgExplore = true;
			expedition.partyShare = true;

			expedition.conditionDescription1 = "Find the missing wizard";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardItem(API.ItemIDExpeditionCoupon, 1);
			AddRewardMoney(Item.buyPrice(0, 1, 0, 0));
		}
		public override string Description(bool complete)
		{
			return "There's a... 'magic' letter here from a wizard of some kind was supposed to be moving in, probably to see what kind of magics these spirits of light and dark manifest as or something. He still hasn't arrived though, so would you mind looking for him? And let's not talk about why my hat is singed. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!WorldExplorer.savedClerk) return false;

			if (cond1)
			{
				expedition.conditionDescription2 = "Free the bound wizard";
			}

			if (!cond3)
			{
				cond3 = Main.hardMode;
			}

			// Only active whilst npc isn't saved yet, or the npc has been saved (not just here)
			return (!NPC.savedWizard || cond1) && cond3;
		}

		private const float viewRangeX = 1984f;
		private const float viewRangeY = 1120f;
		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			// Cannot "save" unless player has seen the bound first - only spawns when not saved
			if (!cond1)
			{
				Rectangle viewRect = Utils.CenteredRectangle(player.Center, new Vector2(viewRangeX, viewRangeY));
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].type != NPCID.BoundWizard) continue;
					if (viewRect.Intersects(Main.npc[i].getRect()))
					{
						cond1 = true;
						break;
					}
				}
			}
			// Ensure it is only fulfilled when player is nearby when NPC is saved
			if (cond1 && !cond2)
			{
				cond2 = NPC.savedWizard;
			}
			return cond1 && cond2;
		}
	}
}
