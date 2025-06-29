﻿using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Items.QuestItems
{
	public class PrefixApplicator : ModItem
	{
		public override void SetStaticDefaults()
		{
			/****DisplayName.SetDefault("Prefix Applicator");
            Tooltip.SetDefault("<right> to use on next favourited accessory");*/
		}
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 24;
			Item.consumable = true;
			Item.rare = 0; // Shouldn't be at this value anyway because prefixes
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1, 0, 0);
		}

		Item matchingAccessory = null;
		public override bool CanRightClick()
		{
			return matchingAccessory != null && Item.prefix != 0;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (Item.prefix == 0)
			{
				tooltips.Add(new TooltipLine(Mod, "ApplyPrefixNull", "Apply to: No prefix to apply"));
				return;
			}

			// Search through the inventory for where I am, then
			// look for favourited items from that point, looping 
			// back to where my index is
			int myIndex = -1;

			// iterate first time to find me and items past me
			for (int i = 0; i < Main.LocalPlayer.inventory.Length; i++)
			{
				if (LookForMeAndMatch(ref myIndex, Main.LocalPlayer.inventory[i], i, tooltips))
				{
					return;
				}
			}
			//iterate a second time and end at me
			for (int i = 0; i < myIndex; i++)
			{
				if (LookForMeAndMatch(ref myIndex, Main.LocalPlayer.inventory[i], i, tooltips))
				{
					return;
				}
			}

			matchingAccessory = null;
			tooltips.Add(new TooltipLine(Mod, "ApplyPrefixNone", "Apply to: No favourited accessory"));
		}

		private bool LookForMeAndMatch(ref int myIndex, Item invItem, int i, List<TooltipLine> tooltips)
		{
			if (myIndex == -1)
			{
				if (!invItem.IsNotSameTypePrefixAndStack(this.Item)) { myIndex = i; } //**** was using "Item.IsTheSameAs" (without the !)
			}
			else
			{
				if (invItem.accessory &&
					invItem.type != Item.type &&
					invItem.prefix != Item.prefix &&
					invItem.favorited)
				{
					matchingAccessory = invItem;
					tooltips.Add(new TooltipLine(Mod, "ApplyPrefixAccessory", "Apply to: " + invItem.Name));
					return true;
				}
			}
			return false;
		}

		bool consume;
		public override void RightClick(Player player)
		{
			if (matchingAccessory != null && Item.prefix != 0)
			{
				// Apply the new prefix
				matchingAccessory.Prefix(Item.prefix);

				// Make it obvious it's changed
				matchingAccessory.favorited = false;
				matchingAccessory.newAndShiny = true;

				consume = true;
			}
			else
			{
				consume = false;
			}
		}
		public override bool ConsumeItem(Player player)
		{
			return consume;
		}
	}
}
