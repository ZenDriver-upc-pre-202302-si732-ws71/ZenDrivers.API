﻿namespace ZenDrivers.API.Shared.Domain.Models;

public interface IBaseEntity<TId>
{
    public TId Id { get; set; }
}