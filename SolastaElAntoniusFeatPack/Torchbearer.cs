using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaModApi;
using SolastaModApi.Extensions;
using SolastaModApi.Infrastructure;
using SolastaModHelpers;
using UnityEngine.AddressableAssets;
using TA;

using Helpers = SolastaModHelpers.Helpers;
using NewFeatureDefinitions = SolastaModHelpers.NewFeatureDefinitions;
using ExtendedEnums = SolastaModHelpers.ExtendedEnums;

namespace SolastaElAntoniusFeatPack
{
    class TorchbearerFeatBuilder : BaseDefinitionBuilder<FeatDefinition>
    {
        const string TorchbearerFeatName = "TorchbearerFeat";
        private static readonly string TorchbearerFeatNameGuid = GuidHelper.Create(Core.FP_GUID, TorchbearerFeatName).ToString();

        protected TorchbearerFeatBuilder(string name, string guid) : base(DatabaseHelper.FeatDefinitions.Ambidextrous, name, guid)
        {
            Definition.GuiPresentation.Title = "Feat/&TorchbearerTitle";
            Definition.GuiPresentation.Description = "Feat/&TorchbearerDescription";

            Definition.Features.Clear();
            Definition.Features.Add(buildFeatureTorchbearer());

            Definition.SetMinimalAbilityScorePrerequisite(false);
        }

        public static FeatDefinition CreateAndAddToDB(string name, string guid)
            => new TorchbearerFeatBuilder(name, guid).AddToDB();

        public static FeatDefinition TorchbearerFeat = CreateAndAddToDB(TorchbearerFeatName, TorchbearerFeatNameGuid);

        public static void AddToFeatList()
        {
            var TorchbearerFeat = TorchbearerFeatBuilder.TorchbearerFeat;
        }

        private static FeatureDefinition buildFeatureTorchbearer()
        {
            return Helpers.FeatureBuilder<FeatureDefinitionPower>.createFeature
            (
                "PowerTorchbearer",
                GuidHelper.Create(Core.FP_GUID, "PowerTorchbearer").ToString(),
                "Feature/&PowerTorchbearerTitle",
                "Feature/&PowerTorchbearerDescription",
                null
            );
        }
    }
}
