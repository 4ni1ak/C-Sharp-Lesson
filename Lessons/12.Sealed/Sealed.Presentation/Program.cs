using System;

sealed class OuterClass
{
    public sealed class SealedInnerClass
    {
        public void SealedMethod()
        {
            Console.WriteLine("SealedMethod is called from SealedInnerClass.");
        }
    }

    sealed class DerivedSealedInnerClass
    {
        public void UseSealedMethod()
        {
            Console.WriteLine("UseSealedMethod is called from DerivedSealedInnerClass.");
        }
    }


    static void Main()
    {
        SealedInnerClass sealedInnerInstance = new SealedInnerClass();
        sealedInnerInstance.SealedMethod();

        DerivedSealedInnerClass derivedInstance = new DerivedSealedInnerClass();
        derivedInstance.UseSealedMethod();
    }
}