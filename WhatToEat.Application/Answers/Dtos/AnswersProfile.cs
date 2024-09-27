using AutoMapper;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Dtos;

public class AnswersProfile : Profile
{
    public AnswersProfile()
    {
        CreateMap<Answer, AnswerDto>();
    }
}
