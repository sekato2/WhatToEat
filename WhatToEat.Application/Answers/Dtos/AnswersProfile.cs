using AutoMapper;
using WhatToEat.Application.Answers.Commands.CreateAnswer;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Answers.Dtos;

public class AnswersProfile : Profile
{
    public AnswersProfile()
    {
        CreateMap<Answer, AnswerDto>();
        CreateMap<CreateAnswerCommand, Answer>();
    }
}
