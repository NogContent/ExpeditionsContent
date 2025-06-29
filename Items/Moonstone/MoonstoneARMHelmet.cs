﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Items.Moonstone
{
	[AutoloadEquip(EquipType.Head)]
	public class MoonstoneARMHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			/****DisplayName.SetDefault("Yutu Helmet");
            Tooltip.SetDefault("Halves damage taken from drowning\n"
                + "Provides a dim light");*/

			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.defense = 7;
			Item.rare = 3;
			Item.value = Item.sellPrice(0, 2, 40, 0); // Sum of gems * 0.8
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Moonstone>(), 10);
			recipe.AddIngredient(ItemID.Silk, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override void UpdateEquip(Player player)
		{
			// Add liquid protection
			if (player.breath <= 0 && player.breathCD == 0) player.statLife++; // halve drowning damage per tick

			// Tiny light around player so darkness isn't complete darkness
			Lighting.AddLight(player.Center, 0.04f, 0.08f, 0.12f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return
				body.type == ModContent.ItemType<MoonstoneARMTunic>() &&
				legs.type == ModContent.ItemType<MoonstoneARMPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly increases movement capabilities\nPress UP or DOWN to control jump height";

			// Better movespeed
			player.moveSpeed += 0.05f; // 10% movement speed
			player.runAcceleration *= 1.5f; // 50% increased acceleration

			// Increased jump power (Up to 40 blocks exactly!)
			//player.autoJump = true;
			player.jumpBoost = true; // Use increased base jump speed
									 //player.jumpSpeedBoost += 2.4f;
			player.extraFall += 20; // 20 extra blocks fall resist (15+20=35)

			if (player.velocity.Y * player.gravDir < 0) // Floaty + controlled jumps when rising
			{
				player.slowFall = true;
			}

			// Better Mining
			player.pickSpeed -= 0.1f; // total 20% pick speed
		}

		/****public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }*/
	}
}
