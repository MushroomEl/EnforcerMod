﻿using Modules;
using RoR2;

namespace EnforcerPlugin.Achievements {
    public class FrogAchievement : GenericModdedUnlockable {
        public override string AchievementTokenPrefix => "ENFORCER_FROG" + knee.grow;
        public override string PrerequisiteUnlockableIdentifier => "ENFORCER_CHARACTERUNLOCKABLE_ACHIEVEMENT_ID";

        public override string AchievementSpriteName => "texZeroSuitAchievement";

        public override BodyIndex LookUpRequiredBodyIndex() {
            return BodyCatalog.FindBodyIndex("EnforcerBody");
        }
        // Token: 0x06003926 RID: 14630 RVA: 0x000DD289 File Offset: 0x000DB489
        public override void OnBodyRequirementMet() {
            base.OnBodyRequirementMet();

            base.SetServerTracked(true);
        }

        // Token: 0x06003927 RID: 14631 RVA: 0x000DD298 File Offset: 0x000DB498
        public override void OnBodyRequirementBroken() {
            base.SetServerTracked(false);

            base.OnBodyRequirementBroken();
        }

        public class FrogAchievementServer : RoR2.Achievements.BaseServerAchievement {

            public override void OnInstall() {
                base.OnInstall();

                On.RoR2.FrogController.Pet += FrogController_Pet;
            }

            public override void OnUninstall() {
                base.OnUninstall();

                On.RoR2.FrogController.Pet -= FrogController_Pet;
            }

            private void FrogController_Pet(On.RoR2.FrogController.orig_Pet orig, FrogController self, Interactor interactor) {
                orig(self, interactor);

                base.Grant();

                base.GetCurrentBody().GetComponent<EnforcerNetworkComponent>().Uhh(Skins.getEnforcerSkinIndex(Skins.EnforcerSkin.FUCKINGFROG));
            }
        }
    }
}