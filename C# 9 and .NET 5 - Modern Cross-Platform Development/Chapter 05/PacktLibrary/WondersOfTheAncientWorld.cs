namespace Packt.Shared
{
    /* Use the enum values to store combinations of discrete options.
        Derive an enum type from byte if there are up to eight options, from ushort
        if there are up to 16 options, from uint if there are up to 32 options, and from
        ulong if there are up to 64 options. */
    [System.Flags]
    public enum WondersOfTheAncientWorld : byte
    {
        None = 0b_0000_0000, // 0
        GreatPyramidOfGiza = 0b_0000_0001, // 1
        HangingGardensOfBabylon = 0b_0000_0010, // 2
        StatueOfZeusAtOlympia = 0b_0000_0100, // 4
        TempleOfArtemisAtEphesus = 0b_0000_1000, // 8
        MausoleumAtHalicarnassus = 0b_0001_0000, // 16
        ColossusOfRhodes = 0b_0010_0000, // 32
        LighthouseOfAlexandria = 0b_0100_0000//64
    }
}