﻿namespace ReflectionLoadingAssembliesDynamically.Models
{
    public interface IPlugin
    {
        string Name { get; }
        void Execute();
    }
}
