using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LunarFrost.Items
{

    public class MoonBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Tome");
            Tooltip.SetDefault("This sacred text has been said to draw power from the moon making it stronger during the night.");
        }

        public override void SetDefaults()
        {
            item.damage = 56;             
            item.magic = true;
            item.width = 12;
            item.height = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;        
            item.value = 0;
            item.rare = 1;
            item.mana = 6;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("MagicProjectile");
            item.shootSpeed = 20f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(!Main.dayTime){
                item.damage = 63;
                item.useTime = 25;
                item.mana = 4;
                item.shootSpeed = 25f;
            }

            if(Main.dayTime){
                item.damage = 56;
                item.useTime = 30;
                item.mana = 6;
                item.shootSpeed = 20;
            }
              float numberProjectiles = 3;
              float rotation = MathHelper.ToRadians(5);
              position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f;
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}