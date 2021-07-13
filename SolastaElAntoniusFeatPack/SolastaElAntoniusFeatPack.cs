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

    public class DualFlurryApplyConditionOnAttackHit : FeatureDefinition, NewFeatureDefinitions.IInitiatorApplyEffectOnAttackHit
    {
        // This implements an ApplyOnAttackHit Interface to define a prerequisite condition and a granted condition. If the
        // attacker hits, the prereq condition is applied, but if the prereq condition is already acting on the attacker,
        // the grant condition is applied
        public bool apply_to_attacker;
        public ConditionDefinition prereq_condition;
        public ConditionDefinition grant_condition;
        public int durationValue;
        public RuleDefinitions.DurationType durationType;
        public RuleDefinitions.TurnOccurenceType turnOccurence;


        public void initialize_applicator(bool set_apply_to_attacker, ConditionDefinition set_prereq_condition, ConditionDefinition set_grant_condition, int set_duration, RuleDefinitions.DurationType set_duration_type, RuleDefinitions.TurnOccurenceType set_turn_occurence)
        {
            apply_to_attacker = set_apply_to_attacker;
            prereq_condition = set_prereq_condition;
            grant_condition = set_grant_condition;
            durationValue = set_duration;
            durationType = set_duration_type;
            turnOccurence = set_turn_occurence;
        }

        public void processAttackHitInitiator(GameLocationCharacter attacker, GameLocationCharacter defender, ActionModifier attack_modifier, int attackRoll, int successDelta, bool ranged)
        {
            var dest_char = apply_to_attacker ? attacker : defender;

            var condition = dest_char.RulesetCharacter.HasConditionOfType(prereq_condition.name) ? grant_condition : prereq_condition;

            RulesetCondition active_condition = RulesetCondition.CreateActiveCondition(dest_char.RulesetCharacter.Guid,
                                                                                       condition, durationType, durationValue, turnOccurence,
                                                                                       attacker.RulesetCharacter.Guid,
                                                                                       attacker.RulesetCharacter.CurrentFaction.Name);
            dest_char.RulesetCharacter.AddConditionOfCategory("10Combat", active_condition, true);
        }
    }
}
