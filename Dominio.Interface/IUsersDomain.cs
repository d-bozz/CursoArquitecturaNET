﻿using Dominio.Entity;

namespace Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate (string username, string password);
    }
}
