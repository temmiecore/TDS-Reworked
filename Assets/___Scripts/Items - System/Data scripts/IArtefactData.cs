using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class IArtefactData : IItemData
{
    public ArtifactType type;

    public abstract void Activate();
    public abstract void Deactivate();
}

/// Note - indexes in the enumerator should be the same as indexes in GameManager consumablePrefabs List
/// TODO: Add all remaining items to enum according to their indexing
public enum ArtifactType
{
    vampiricTooth,
    manaStone,
    beltStrength,
    bootsAgility,
    cloakFlames,
    razorDagger,
    legionMedallion

}