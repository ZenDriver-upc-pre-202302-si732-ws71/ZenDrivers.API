namespace ZenDrivers.API.Shared.Mapping;

public class GenericNoneMap<TFrom> : IGenericMap<TFrom, TFrom> where TFrom : class
{
    public TFrom Map(TFrom from, TFrom to) => from;
}