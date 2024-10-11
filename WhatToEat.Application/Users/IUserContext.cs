namespace WhatToEat.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}