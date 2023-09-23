using AutoMapper;

namespace ZenDrivers.API.Shared.Mapping;

public class GenericMap<TFrom, TTo> : IGenericMap<TFrom, TFrom> where TFrom : class
{
    private readonly IMapper _mapper;

    public GenericMap(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TFrom Map(TFrom from, TFrom to)
    {
        var value = _mapper.Map<TFrom, TTo>(from);
        return _mapper.Map(value, to);
    }
}
