﻿using AutoMapper;
using WhatToEat.Application.Questions.Commands.CreateQuestion;
using WhatToEat.Domains.Entities;

namespace WhatToEat.Application.Questions.Dtos;

public class QuestionsProfile : Profile
{
    public QuestionsProfile() {
        CreateMap<CreateQuestionCommand, Question>();

        CreateMap<Question, QuestionDto>()
            .ForMember(y => y.Answers, opt => opt.MapFrom(src => src.Answers));
    }
}
