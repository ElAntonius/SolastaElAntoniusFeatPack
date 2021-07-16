using UnityModManagerNet;
using System;

namespace SolastaElAntoniusFeatPack
{
    public class Core
    {
        const string pack_guid = "03C523EB-91B9-4F1B-A697-804D1BC2D6DD";
        public static Guid FP_GUID = new Guid(pack_guid);
    }

    public class Settings : UnityModManager.ModSettings
    {
        public bool dualFlurryEnable = true;
        public bool torchBearerEnable = true;
    }
}
