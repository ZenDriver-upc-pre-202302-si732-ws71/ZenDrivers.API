﻿using AutoMapper;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Recruiters.Mapping;

public class PostMap : GenericMap<Post, PostUpdateResource>
{
    public PostMap(IMapper mapper) : base(mapper)
    {}
}