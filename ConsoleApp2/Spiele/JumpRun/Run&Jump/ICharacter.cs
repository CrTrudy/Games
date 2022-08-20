namespace StreetRun
{
    public interface ICharacter
    {
        char CharSymbol { get; }
        int Hight { get; }

        void Springen(ConsoleKey key);
        void Fallen();
    }
}