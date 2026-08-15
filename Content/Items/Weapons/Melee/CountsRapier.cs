using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CatharsisReborn.Content.Projectiles;

namespace CatharsisReborn.Content.Items.Weapons.Melee
{
    public class CountsRapier : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.useAnimation = 12;
            Item.useTime = 18;
            Item.width = 46;
            Item.height = 48;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item

            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 0, 10);

            Item.shoot = ModContent.ProjectileType<CountsRapierProjectile>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
        }

        // Since this weapon is a projectile (uses noUseGraphic), it isn't naturally considered a melee weapon for the purposes of prefixes. This allows the expected prefixes to be applied.
        public override bool MeleePrefix() => true;
        }
    }
