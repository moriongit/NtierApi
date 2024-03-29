﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.CommentDtos;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Interfaces;

namespace Twitter.Business.Services.Implements
{
    public class CommentService: ICommentService
    {
        

        ICommentRepository _repo { get; }
        IMapper _mapper { get; }

        public CommentService(IMapper mapper, ICommentRepository repo) 
        {
            _mapper = mapper;
            _repo = repo;
        }

        public IEnumerable<CommentListItemDto> GetAll()
            =>_mapper.Map<IEnumerable<CommentListItemDto>>(_repo);

    }
}
